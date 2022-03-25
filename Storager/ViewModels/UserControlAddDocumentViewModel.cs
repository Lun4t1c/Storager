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


        private DocumentTypeModel _selectedDocumentType;
        private BindableCollection<StockModel> _selectedStocks = new BindableCollection<StockModel>();

        public DocumentTypeModel SelectedDocumentType
        {
            get { return _selectedDocumentType; }
            set { _selectedDocumentType = value; NotifyOfPropertyChange(() => SelectedDocumentType); }
        }

        public BindableCollection<StockModel> SelectedStocks
        {
            get { return _selectedStocks; }
            set { _selectedStocks = value; NotifyOfPropertyChange(() => SelectedStocks); }
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
            throw new NotImplementedException();
        }

        private void AddSelectedStock()
        {
            SelectedStocks.Add(new StockModel() { Amount = 100, CurrentAmount = 100, PricePerUnit = 99.99M });
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
