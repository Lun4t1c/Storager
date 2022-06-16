using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlStorageRacksViewModel : Screen
    {
        #region Properties
        private BindableCollection<StorageRackModel> _storageRacks = DataAcces.GetAllStorageRacks();
        private BindableCollection<StockModel> _selectedStocks = null;

        public BindableCollection<StorageRackModel> StorageRacks
        {
            get { return _storageRacks; }
            set { _storageRacks = value; NotifyOfPropertyChange(() => StorageRacks); }
        }        

        public BindableCollection<StockModel> SelectedStocks
        {
            get { return _selectedStocks; }
            set { _selectedStocks = value; NotifyOfPropertyChange(() => SelectedStocks); }
        }

        #endregion

        #region Constructor
        public UserControlStorageRacksViewModel()
        {

        }
        #endregion

        #region Methods
        public void StorageRackItemClick(StorageRackModel storageRack)
        {
            SelectedStocks = storageRack.Stocks;
        }

        private void AddStorageRack()
        {
            IWindowManager windowManager = new WindowManager();
            windowManager.ShowWindowAsync(new ViewModels.WindowAddStorageRackViewModel());
        }
        #endregion

        #region Button clicks
        public void AddStorageRackButton()
        {
            AddStorageRack();
        }
        #endregion
    }
}
