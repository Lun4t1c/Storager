using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlAddDocumentViewModel : Screen
    {
        #region Properties
        public BindableCollection<DocumentTypeModel> DocumentTypes { get; set; } = DataAcces.GetAllDocumentTypes();
        public BindableCollection<ProductModel> Products { get; set; } = DataAcces.GetAllProducts();
        public BindableCollection<StorageRackModel> StorageRacks { get; set; } = DataAcces.GetAllStorageRacks();


        private DocumentTypeModel _selectedDocumentType = null;
        private BindableCollection<StockModel> _selectedStocks = new BindableCollection<StockModel>();
        private string _selectedSupplier = null;
        private string _selectedInvoiceNumber = null;
        private string _warningMessage = string.Empty;

        public DocumentTypeModel SelectedDocumentType
        {
            get { return _selectedDocumentType; }
            set 
            {
                _selectedDocumentType = value; 
                NotifyOfPropertyChange(() => SelectedDocumentType);
                SwitchDocumentType(value.ShortName);
            }
        }

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
        public UserControlAddDocumentViewModel()
        {

        }
        #endregion


        #region Methods
        private void Confirm()
        {
            if (!isFormValid()) return;
            
            DocumentModel document = new DocumentModel() 
            {
                Supplier = SelectedSupplier,
                InvoiceNumber = SelectedInvoiceNumber,
                DateOfSigning = DateTime.Now,
                Stocks = new List<StockModel>(SelectedStocks)
            };

            DataAcces.InsertDocument(document);
        }

        private void AddSelectedStock()
        {
            SelectedStocks.Add(new StockModel());
            //SelectedStocks.Add(stock);
        }

        private void ShowSelectedStockAdder()
        {
            new WindowManager().ShowWindowAsync(new WindowPopupAdderViewModel(new UserControlAddStockViewModel())
            );
        }
        
        private void SwitchDocumentType(string type)
        {
            switch (type)
            {
                case "PZ":
                    SwitchToPZ();
                    break;

                case "WZ":
                    SwitchToWZ();
                    break;

                default:
                    break;
            }
        }

        private void SwitchToPZ()
        {
            throw new NotImplementedException();
        }

        private void SwitchToWZ()
        {
            throw new NotImplementedException();
        }

        private bool isFormValid()
        {
            bool result = true;

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

            return true;
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
