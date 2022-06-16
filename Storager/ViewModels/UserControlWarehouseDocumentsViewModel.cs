using Caliburn.Micro;
using Storager.Misc;
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
        private SortModeAndOrder _sortMode;

        public BindableCollection<DocumentBaseModel> Documents
        {
            get { return _documents; }
            set { _documents = value; NotifyOfPropertyChange(() => Documents); }
        }        

        public SortModeAndOrder SortMode
        {
            get { return _sortMode; }
            set { _sortMode = value; NotifyOfPropertyChange(() => SortMode); }
        }
        #endregion

        #region Constructor
        public UserControlWarehouseDocumentsViewModel()
        {
            Documents.AddRange(DataAcces.GetAllDocumentsPz());
            Documents.AddRange(DataAcces.GetAllDocumentsWz());

            SortDocuments();            
        }
        #endregion

        #region Methods
        private void SortDocuments()
        {
            Documents = new BindableCollection<DocumentBaseModel>(Documents.OrderByDescending(doc => doc.DateOfSigning));
        }

        private void AddDocument()
        {
            var window = System.Windows.Window.GetWindow((System.Windows.Controls.UserControl)this.GetView());
            WindowShellViewModel shell = window.DataContext as WindowShellViewModel;
            shell?.AddDocumentButton();
        }
        #endregion

        #region Button clicks
        public void DocumentItemClick(DocumentBaseModel document)
        {
            IWindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(new ViewModels.WindowDocumentInspectorViewModel(document));
        }

        public void AddDocumentButton()
        {

        }
        #endregion
    }
}
