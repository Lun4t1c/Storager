using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlAddDocumentWZViewModel : Screen
    {
        #region Properties
        private string _selectedSupplier = string.Empty;
        private string _selectedInvoiceNumber = string.Empty;
        private BindableCollection<ProductModel> _productsInDatabase = DataAcces.GetAllProducts();
        private BindableCollection<ProductModel> _filteredProducts = DataAcces.GetAllProducts();
        private BindableCollection<ProductModel> _selectedProducts = new BindableCollection<ProductModel>();
        private string _stocksFilterText = string.Empty;
        private string _warningMessage = string.Empty;

        public string SelectedSupplier
        {
            get { return _selectedSupplier; }
            set { _selectedSupplier = value; NotifyOfPropertyChange(() => SelectedSupplier); }
        }

        public string SelectedInvoiceNumber
        {
            get { return _selectedInvoiceNumber; }
            set { _selectedInvoiceNumber = value; NotifyOfPropertyChange(() => SelectedInvoiceNumber); }
        }

        public BindableCollection<ProductModel> ProductsInDatabase
        {
            get { return _productsInDatabase; }
            set { _productsInDatabase = value; NotifyOfPropertyChange(() => ProductsInDatabase); }
        }

        public BindableCollection<ProductModel> FilteredProducts
        {
            get { return _filteredProducts; }
            set { _filteredProducts = value; NotifyOfPropertyChange(() => FilteredProducts); }
        }

        public BindableCollection<ProductModel> SelectedProducts
        {
            get { return _selectedProducts; }
            set { _selectedProducts = value; NotifyOfPropertyChange(() => SelectedProducts); }
        }

        public string ProductsFilterText
        {
            get { return _stocksFilterText; }
            set { _stocksFilterText = value; NotifyOfPropertyChange(() => ProductsFilterText); FilterProducts(); }
        }

        public string WarningMessage
        {
            get { return _warningMessage; }
            set { _warningMessage = value; NotifyOfPropertyChange(() => WarningMessage); }
        }
        #endregion


        #region Constructor
        public UserControlAddDocumentWZViewModel()
        {

        }
        #endregion


        #region Methods
        private async void Confirm()
        {
            if (!isFormValid()) return;

            DocumentModel document = new DocumentModel()
            {
                Supplier = SelectedSupplier,
                InvoiceNumber = SelectedInvoiceNumber,
                DateOfSigning = DateTime.Now,
                //Stocks = new BindableCollection<ProductModel>(SelectedProducts),
                DocumentType = ((UserControlAddDocumentViewModel)Parent).SelectedDocumentType
            };

            try
            {
                await Task.Run(() => DataAcces.InsertDocument(document));

                foreach (StockModel stock in document.Stocks)
                    DataAcces.UpdateStockCurrentAmount(stock, stock.CurrentAmount - stock.WithdrawnAmount);

                ResetForm();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "ERROR", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }            
        }

        private void AddSelectedProduct(ProductModel product)
        {
            ProductsInDatabase.Remove(product);
            FilteredProducts.Remove(product);
            SelectedProducts.Add(product);
        }

        private bool isFormValid()
        {
            throw new NotImplementedException();
        }

        private bool isStockValid(StockModel stock)
        {
            if (stock.WithdrawnAmount > stock.CurrentAmount) return false;

            return true;
        }
        
        private void FilterProducts()
        {
            if (string.IsNullOrEmpty(ProductsFilterText))
            {
                FilteredProducts = new BindableCollection<ProductModel>(ProductsInDatabase);
            }
            else
            {
                IEnumerable<ProductModel> tempList =
                        from product
                        in ProductsInDatabase
                        where product.Name.ToLower().Contains(ProductsFilterText)
                        select product;

                FilteredProducts = new BindableCollection<ProductModel>(tempList);
            }
        }
        
        private void ResetForm()
        {
            SelectedSupplier = string.Empty;            
            SelectedProducts = new BindableCollection<ProductModel>();
            SelectedInvoiceNumber = string.Empty;
            WarningMessage = string.Empty;

            ProductsInDatabase = DataAcces.GetAllProducts();
            ProductsFilterText = string.Empty;
            FilterProducts();
        }
        #endregion


        #region Button clicks
        public void ConfirmButton()
        {
            Confirm();
        }
        #endregion
    }
}
