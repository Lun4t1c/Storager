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

            Documents = new BindableCollection<DocumentBaseModel>(Documents.OrderBy(doc => doc.DateOfSigning));
            
        }
        #endregion

        #region Methods

        #endregion

        #region Button clicks
        public void DocumentItemClick(DocumentBaseModel document)
        {
            IWindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(new ViewModels.WindowDocumentInspectorViewModel(document));
        }
        #endregion
    }
}
