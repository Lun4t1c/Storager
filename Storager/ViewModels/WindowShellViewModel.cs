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
        public UserModel LoggedUser { get; set; }
        #endregion

        #region Constructor
        public WindowShellViewModel(UserModel userModel = null)
        {
            LoggedUser = userModel;
            //ActivateItemAsync(new UserControlLoginViewModel());
        }
        #endregion

        #region Methods
        private async void DisplayProducts()
        {
            DisplayLoadingScreen("Loading products...");
            await ActivateItemAsync(new UserControlProductsViewModel());
        }

        private void DisplayStorageLayout()
        {
            DisplayLoadingScreen("Loading storage layout...");
        }

        private void ShowSettingsWindow()
        {
            IWindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(new ViewModels.WindowSettingsViewModel());
        }

        private async void DisplayLoadingScreen(string loadingText = "")
        {
            await ActivateItemAsync(new UserControlLoadingScreenViewModel(loadingText));
        }

        private async void DisplayAddProductControl()
        {
            DisplayLoadingScreen();
            await ActivateItemAsync(new UserControlAddProductViewModel());
        }

        private async void DisplayDocuments()
        {
            DisplayLoadingScreen("Loading documents...");
            await ActivateItemAsync(new UserControlWarehouseDocumentsViewModel());
        }

        private async void ShowToast(string text)
        {

        }
        #endregion

        #region Button clicks
        public void ProductsButton()
        {
            DisplayProducts();
        }

        public void StorageLayoutButton()
        {
            DisplayStorageLayout();
        }

        public void SettingsButton()
        {
            ShowSettingsWindow();
        }

        public void AddProductButton()
        {
            DisplayAddProductControl();
        }

        public void DocumentsButton()
        {
            DisplayDocuments();
        }
        public void TestButton()
        {
            foreach (string item in dummydata.GenerateRandomNames())
            {
                Console.WriteLine(item);                
            }
            Console.WriteLine();
        }
        #endregion
    }
}
