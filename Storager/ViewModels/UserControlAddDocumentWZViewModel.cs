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
        public BindableCollection<ContractorModel> AllContractors { get; set; } = DataAcces.GetAllContractors();

        private ContractorModel _selectedRecipent = null;
        private string _selectedInvoiceNumber = string.Empty;
        private BindableCollection<ProductModel> _productsInDatabase = DataAcces.GetAllProducts();
        private BindableCollection<ProductModel> _filteredProducts = DataAcces.GetAllProducts();
        private BindableCollection<ProductAndAmount> _selectedProductsAndAmount = new BindableCollection<ProductAndAmount>();
        private string _productsFilterText = string.Empty;
        private string _warningMessage = string.Empty;

        public ContractorModel SelectedRecipent
        {
            get { return _selectedRecipent; }
            set { _selectedRecipent = value; NotifyOfPropertyChange(() => SelectedRecipent); }
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

        public BindableCollection<ProductAndAmount> SelectedProductsAndAmount
        {
            get { return _selectedProductsAndAmount; }
            set { _selectedProductsAndAmount = value; NotifyOfPropertyChange(() => SelectedProductsAndAmount); }
        }

        public string ProductsFilterText
        {
            get { return _productsFilterText; }
            set { _productsFilterText = value; NotifyOfPropertyChange(() => ProductsFilterText); FilterProducts(); }
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

            DocumentWzModel document_wz = new DocumentWzModel()
            {
                Recipent = SelectedRecipent,
                InvoiceNumber = SelectedInvoiceNumber,
                DateOfSigning = DateTime.Now,
                ProductsAndAmount = new BindableCollection<ProductAndAmount>(SelectedProductsAndAmount),
                Id_ApprovedBy = Globals.LoggedUser.Id
            };

            try
            {
                await Task.Run(() => DataAcces.InsertDocumentWz(document_wz));

                foreach (ProductAndAmount productAndAmount in SelectedProductsAndAmount)
                {
                    int amount_withdrawn = productAndAmount.Amount;
                    BindableCollection<StockModel> StocksWithProduct = DataAcces.GetNonEmptyStocksWithProduct(productAndAmount.Product);

                    foreach (StockModel stock in StocksWithProduct)
                    {
                        if (amount_withdrawn > stock.CurrentAmount)
                        {
                            amount_withdrawn -= stock.CurrentAmount;
                            await Task.Run(() => DataAcces.UpdateStockCurrentAmount(stock, 0));
                        }
                        else if (amount_withdrawn <= stock.CurrentAmount)
                        {
                            await Task.Run(() => DataAcces.UpdateStockCurrentAmount(stock, stock.CurrentAmount - amount_withdrawn));
                            break;
                        }
                    }
                }

                WarningMessage = "Successfully added document";
                ResetForm();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "ERROR", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }            
        }

        private bool isFormValid()
        {
            bool result = true;
            WarningMessage = "";

            if (!isSelectedProductsValid())
            {
                WarningMessage += "Selected products are invalid.\n";
                result = false;
            }

            return result;
        }

        private bool isSelectedProductsValid()
        {
            foreach (ProductAndAmount productAndAmount in SelectedProductsAndAmount)
                if (productAndAmount.Amount > productAndAmount.Product.AmountLeft) return false;

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
        
        private void AddSelectedProductAndAmount(ProductAndAmount productAndAmount)
        {
            SelectedProductsAndAmount.Add(productAndAmount);
        }

        private void ResetForm()
        {
            SelectedRecipent = null;            
            SelectedProductsAndAmount = new BindableCollection<ProductAndAmount>();
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

        public void ProductItemClick(ProductModel product)
        {
            AddSelectedProductAndAmount(new ProductAndAmount(product, 0));
        }
        #endregion
    }
}
