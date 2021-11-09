using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class WindowWelcomeViewModel : Conductor<object>
    {
        #region Properties

        #endregion

        #region Constructor
        public WindowWelcomeViewModel()
        {
            ActivateItemAsync(new UserControlLoginViewModel());
        }
        #endregion

        #region Methods

        #endregion
    }
}
