using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlAddDocumentViewModel : Conductor<object>
    {
        #region Properties
        public BindableCollection<DocumentTypeModel> DocumentTypes { get; set; } = DataAcces.GetAllDocumentTypes();

        private DocumentTypeModel _selectedDocumentType = null;

        public DocumentTypeModel SelectedDocumentType
        {
            get { return _selectedDocumentType; }
            set 
            {
                _selectedDocumentType = value; 
                NotifyOfPropertyChange(() => SelectedDocumentType);
                SwitchDocumentType(value?.ShortName);
            }
        }
        #endregion


        #region Constructor
        public UserControlAddDocumentViewModel()
        {

        }
        #endregion


        #region Methods       
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
            ActivateItemAsync(new UserControlAddDocumentPZViewModel());
            
        }

        private void SwitchToWZ()
        {
            ActivateItemAsync(new UserControlAddDocumentWZViewModel());
        }
        #endregion


        #region Button clicks

        #endregion
    }
}
