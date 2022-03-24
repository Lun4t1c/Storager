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
        private BindableCollection<DocumentTypeModel> _documentTypes = dummydata.GetDocuments();

        public BindableCollection<DocumentTypeModel> DocumentTypes
        {
            get { return _documentTypes; }
            set { _documentTypes = value; NotifyOfPropertyChange(() => DocumentTypes); }
        }

        private BindableCollection<StorageRackModel> _racks = DataAcces.GetAllStorageRacks();

        public BindableCollection<StorageRackModel> Racks
        {
            get { return _racks; }
            set { _racks = value; NotifyOfPropertyChange(() => Racks); }
        }


        private DocumentTypeModel _selectedDocument;
        private BindableCollection<StockModel> _selectedStocks;

        public DocumentTypeModel SelectedDocument
        {
            get { return _selectedDocument; }
            set { _selectedDocument = value; NotifyOfPropertyChange(() => SelectedDocument); }
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

        private void AddStock()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Button clicks
        public void ConfirmButton()
        {
            Confirm();
        }

        public void AddStockButton()
        {
            AddStock();
        }
        #endregion
    }
}
