using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlAddStockViewModel : Misc.IAdder
    {
        #region Properties

        #endregion

        #region Constructor
        public UserControlAddStockViewModel()
        {

        }

        #endregion

        #region Methods
        protected override void InsertIntoDb()
        {
            
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
