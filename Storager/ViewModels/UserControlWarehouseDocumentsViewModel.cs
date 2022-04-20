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
        private BindableCollection<DocumentModel> _documents = DataAcces.GetAllDocuments();

        public BindableCollection<DocumentModel> Documents
        {
            get { return _documents; }
            set { _documents = value; NotifyOfPropertyChange(() => Documents); }
        }
        #endregion

        #region Constructor
        public UserControlWarehouseDocumentsViewModel()
        {

        }
        #endregion

        #region Methods

        #endregion

    }
}
