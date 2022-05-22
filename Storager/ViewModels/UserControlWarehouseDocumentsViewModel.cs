using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlWarehouseDocumentsViewModel : Screen
    {
        #region Properties
        private BindableCollection<DocumentBaseModel> _documents = new BindableCollection<DocumentBaseModel>();

        public BindableCollection<DocumentBaseModel> Documents
        {
            get { return _documents; }
            set { _documents = value; NotifyOfPropertyChange(() => Documents); }
        }
        #endregion

        #region Constructor
        public UserControlWarehouseDocumentsViewModel()
        {
            Documents.AddRange(DataAcces.GetAllDocumentsPz());
            Documents.AddRange(DataAcces.GetAllDocumentsWz());
        }
        #endregion

        #region Methods

        #endregion

    }
}
