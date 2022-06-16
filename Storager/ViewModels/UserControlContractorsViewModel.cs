using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlContractorsViewModel : Screen
    {
        #region Properties
        public BindableCollection<ContractorModel> Contractors { get; set; } = DataAcces.GetAllContractors();
        #endregion

        #region Constructor
        public UserControlContractorsViewModel()
        {

        }
        #endregion

        #region Methods
        private void AddContractor()
        {
            var window = System.Windows.Window.GetWindow((System.Windows.Controls.UserControl)this.GetView());
            WindowShellViewModel shell = window.DataContext as WindowShellViewModel;
            shell?.AddContractorButton();
        }
        #endregion

        #region Button clicks
        public void AddContractorButton()
        {
            AddContractor();
        }
        #endregion
    }
}
