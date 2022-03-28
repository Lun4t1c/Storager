using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlAddDocumentPZViewModel : Screen
    {
        #region Properties
        public BindableCollection<ProductModel> Products { get; set; } = DataAcces.GetAllProducts();
        public BindableCollection<StorageRackModel> StorageRacks { get; set; } = DataAcces.GetAllStorageRacks();


        private BindableCollection<StockModel> _selectedStocks = new BindableCollection<StockModel>();
        private string _selectedSupplier = null;
        private string _selectedInvoiceNumber = null;
        private string _warningMessage = string.Empty;

        public BindableCollection<StockModel> SelectedStocks
        {
            get { return _selectedStocks; }
            set { _selectedStocks = value; NotifyOfPropertyChange(() => SelectedStocks); }
        }

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

        public string WarningMessage
        {
            get { return _warningMessage; }
            set { _warningMessage = value; NotifyOfPropertyChange(() => WarningMessage); }
        }
        #endregion


        #region Constructor
        public UserControlAddDocumentPZViewModel()
        {

        }
        #endregion


        #region Methods
        private async void Confirm()
        {
            if (!isFormValid()) return;

            foreach (StockModel stock in SelectedStocks)
            {
                stock.CurrentAmount = stock.Amount;
            }

            DocumentModel document = new DocumentModel()
            {
                Supplier = SelectedSupplier,
                InvoiceNumber = SelectedInvoiceNumber,
                DateOfSigning = DateTime.Now,
                Stocks = new List<StockModel>(SelectedStocks),
                DocumentType = ((UserControlAddDocumentViewModel)Parent).SelectedDocumentType
            };

            try
            {
                await Task.Run(() => DataAcces.InsertDocument(document));
                ResetForm();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message, "ERROR", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void AddSelectedStock()
        {
            SelectedStocks.Add(new StockModel());;
        }

        private bool isFormValid()
        {
            bool result = true;
            WarningMessage = string.Empty;

            if (string.IsNullOrEmpty(SelectedSupplier))
            {
                WarningMessage += "Supplier cannot be empty\n";
                result = false;
            }

            foreach (StockModel stock in SelectedStocks)
            {
                if (!stock.IsValid)
                {
                    WarningMessage += "One or more stocks invalid!\n";
                    result = false;
                }
            }

            if (result == true) WarningMessage = string.Empty;
            return result;
        }

        private bool isStockValid(StockModel stock)
        {
            if (stock.Amount <= 0) return false;
            if (stock.PricePerUnit <= 0) return false;
            if (stock.Product == null) return false;
            if (stock.StorageRack == null) return false;

            return true;
        }

        private void ResetForm()
        {
            SelectedSupplier = string.Empty;
            SelectedStocks = new BindableCollection<StockModel>();
            SelectedInvoiceNumber = string.Empty;
            WarningMessage = string.Empty;
        }
        #endregion


        #region Button clicks
        public void ConfirmButton()
        {
            Confirm();
        }

        public void AddSelectedStockButton()
        {
            AddSelectedStock();
        }
        #endregion
    }
}
