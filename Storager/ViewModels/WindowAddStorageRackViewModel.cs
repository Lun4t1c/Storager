using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class WindowAddStorageRackViewModel : Screen
    {
        #region Properties
        private string _selectedCode = null;

        public string SelectedCode
        {
            get { return _selectedCode; }
            set { _selectedCode = value; NotifyOfPropertyChange(() => SelectedCode); }
        }
        #endregion

        #region Constructor
        public WindowAddStorageRackViewModel()
        {

        }
        #endregion

        #region Methods
        private void Confirm()
        {
            if (!isFormValid()) return;

            DataAcces.InsertStorageRack(new StorageRackModel() { Code = SelectedCode });

            var window = System.Windows.Window.GetWindow((System.Windows.Window)this.GetView());
            window.Close();
        }

        private bool isFormValid()
        {
            if (string.IsNullOrEmpty(SelectedCode)) return false;
            return true;
        }
        #endregion

        #region Button clicks
        public void ConfirmButton()
        {
            Confirm();
        }
        #endregion
    }
}
