using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class WindowShellViewModel : Screen
    {
        #region Properties
        public UserModel LoggedUser { get; set; }
        #endregion

        #region Constructor
        public WindowShellViewModel(UserModel userModel = null)
        {
            LoggedUser = userModel;
        }
        #endregion

        #region Methods

        #endregion
    }
}
