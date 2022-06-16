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
        public UserModel LoggedUser { get; set; } = Globals.LoggedUser;
        #endregion

        #region Constructor
        public WindowShellViewModel()
        {

        }
        #endregion

        #region Methods
        private async void DisplayContractors()
        {
            await Task.Run(() => DisplayLoadingScreen("Loading contractors..."));
            UserControlContractorsViewModel userControlContractorsViewModel = await Task.Run(() => new UserControlContractorsViewModel());
            await ActivateItemAsync(userControlContractorsViewModel);
        }

        private async void DisplayAddContractorControl()
        {
            await Task.Run(() => DisplayLoadingScreen());
            UserControlAddContractorViewModel userControlAddContractorViewModel = await Task.Run(() => new UserControlAddContractorViewModel());
            await ActivateItemAsync(userControlAddContractorViewModel);
        }

        private async void DisplayProducts()
        {
            await Task.Run(() => DisplayLoadingScreen("Loading products..."));
            UserControlProductsViewModel userControlProducts = await Task.Run(() => new UserControlProductsViewModel());
            await ActivateItemAsync(userControlProducts);
        }

        private async void DisplayStorageRacks()
        {
            DisplayLoadingScreen("Loading storage racks...");
            UserControlStorageRacksViewModel userControlStorageRacksViewModel = await Task.Run(() => new UserControlStorageRacksViewModel());
            await ActivateItemAsync(userControlStorageRacksViewModel);
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
            UserControlAddProductViewModel userControlAddProductViewModel = await Task.Run(() => new UserControlAddProductViewModel());
            await ActivateItemAsync(userControlAddProductViewModel);
        }

        private async void DisplayDocuments()
        {
            await Task.Run(() => DisplayLoadingScreen("Loading documents..."));
            UserControlWarehouseDocumentsViewModel userControlWarehouseDocumentsViewModel = await Task.Run(() => new UserControlWarehouseDocumentsViewModel());
            await ActivateItemAsync(userControlWarehouseDocumentsViewModel);
        }

        private async void DisplayAddDocumentControl()
        {
            await Task.Run(() => DisplayLoadingScreen());
            UserControlAddDocumentViewModel userControlAddDocumentViewModel = await Task.Run(() => new UserControlAddDocumentViewModel());
            await ActivateItemAsync(userControlAddDocumentViewModel);
        }

        private async void ShowToast(string text)
        {

        }
        #endregion

        #region Button clicks
        public void ContractorsButton()
        {
            DisplayContractors();
        }

        public void AddContractorButton()
        {
            DisplayAddContractorControl();
        }
        public void ProductsButton()
        {
            DisplayProducts();
        }

        public void StorageRacksButton()
        {
            DisplayStorageRacks();
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
            new WindowManager().ShowWindowAsync(new WindowDocumentInspectorViewModel(DataAcces.GetAllDocumentsWz()[0]));
        }


        #region Menu buttons
        public void GenerateRandomProductsButton()
        {
            dummydata.GenerateRandomProducts();
            System.Windows.MessageBox.Show("Generated random products!");
        }

        public void GenerateRandomSeriousProductsButton()
        {
            dummydata.GenerateRandomSeriousProducts();
            System.Windows.MessageBox.Show("Generated random serious products!");
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

        #endregion
    }
}
