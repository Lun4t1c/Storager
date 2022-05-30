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

        #endregion

        #region Constructor
        public WindowShellViewModel()
        {

        }
        #endregion

        #region Methods
        private async void DisplayProducts()
        {
            await Task.Run(() => DisplayLoadingScreen("Loading products..."));
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
            await Task.Run(() => DisplayLoadingScreen());
            await ActivateItemAsync(new UserControlAddProductViewModel());
        }

        private async void DisplayDocuments()
        {
            await Task.Run(() => DisplayLoadingScreen("Loading documents..."));
            await ActivateItemAsync(new UserControlWarehouseDocumentsViewModel());
        }

        private async void DisplayAddDocumentControl()
        {
            await Task.Run(() => DisplayLoadingScreen());
            await ActivateItemAsync(new UserControlAddDocumentViewModel());
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

        public void AddDocumentButton()
        {
            DisplayAddDocumentControl();
        }

        public void TestButton()
        {
            new WindowManager().ShowWindowAsync(new WindowPopupAdderViewModel(new UserControlAddStockViewModel() { AssignedAction = () => { Console.WriteLine("BENG"); } }));
        }


        #region Menu buttons
        public void GenerateRandomProductsButton()
        {
            dummydata.GenerateRandomProducts();
            System.Windows.MessageBox.Show("Generated random products!");
        }

        public void GenerateRandomStocksButton()
        {
            dummydata.GenerateRandomStocks(16);
            System.Windows.MessageBox.Show("Generated random stocks!");
        }

        public void DeleteAllDocumentsDataButton()
        {
            DataAcces.DeleteAllDocumentsData();
            System.Windows.MessageBox.Show("Deleted all documents data!");
        }

        public void DeleteAllStocksDataButton()
        {
            DataAcces.DeleteAllStocksData();
            System.Windows.MessageBox.Show("Deleted all stocks data!");
        }

        public void DeleteAllProductsDataButton()
        {
            DataAcces.DeleteAllProductsData();
            System.Windows.MessageBox.Show("Deleted all products data!");
        }
        #endregion
    }
}
