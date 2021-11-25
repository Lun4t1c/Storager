using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class WindowShellViewModel : Conductor<object>
    {
        #region Properties
        //Currently logged user
        public UserModel LoggedUser { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// WindowShellViewModel constructor
        /// </summary>
        /// <param name="userModel">Logged user</param>
        public WindowShellViewModel(UserModel userModel = null)
        {
            LoggedUser = userModel;
            ActivateItemAsync(new UserControlLoginViewModel());
        }
        #endregion

        #region Methods

        #endregion

        #region Button clicks
        /// <summary>
        /// ProductsButton click
        /// </summary>
        public void ProductsButton()
        {
            Console.WriteLine("Displaying products...");
            ActivateItemAsync(new UserControlProductsViewModel());
        }

        /// <summary>
        /// StorageLayoutButton click
        /// </summary>
        public void StorageLayoutButton()
        {
            Console.WriteLine("Displaying storage layout...");
            ActivateItemAsync(new Misc.LoadingScreen());
        }
        #endregion
    }
}
