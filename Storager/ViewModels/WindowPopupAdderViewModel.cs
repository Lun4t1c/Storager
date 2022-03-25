using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class WindowPopupAdderViewModel : Conductor<object>
    {
        #region Properties
        public delegate void delAction();
        System.Action AssignedAction;
        #endregion

        #region Constructor
        public WindowPopupAdderViewModel(Screen viewModel)
        {
            ActivateItemAsync(viewModel);
            //AssignedAction = action;
        }
        #endregion

        #region Methods

        #endregion

        #region Button clicks
        public void CommitActionButton()
        {
            
        }
        #endregion
    }
}
