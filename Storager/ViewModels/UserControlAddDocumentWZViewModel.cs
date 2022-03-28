using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlAddDocumentWZViewModel : Screen
    {
        #region Properties
        private BindableCollection<StockModel> _stocksInDatabase = DataAcces.GetAllStocks();
        private BindableCollection<StockModel> _selectedStocks = new BindableCollection<StockModel>();
        private string _warningMessage = string.Empty;

        public BindableCollection<StockModel> StocksInDatabase
        {
            get { return _stocksInDatabase; }
            set { _stocksInDatabase = value; NotifyOfPropertyChange(() => StocksInDatabase); }
        }        

        public BindableCollection<StockModel> SelectedStocks
        {
            get { return _selectedStocks; }
            set { _selectedStocks = value; NotifyOfPropertyChange(() => SelectedStocks); }
        }

        public string WarningMessage
        {
            get { return _warningMessage; }
            set { _warningMessage = value; NotifyOfPropertyChange(() => WarningMessage); }
        }
        #endregion


        #region Constructor
        public UserControlAddDocumentWZViewModel()
        {

        }
        #endregion


        #region Methods
        private void Confirm()
        {

        }

        private void AddSelectedStock(StockModel stock)
        {
            SelectedStocks.Add(stock);
        }

        private bool isFormValid()
        {
            bool result = true;

           
            foreach (StockModel stock in SelectedStocks)
            {
                if (!isStockValid(stock))
                {
                    WarningMessage += "One or more stocks invalid\n";
                    result = false;
                    break;
                }
            }

            if (result == true) WarningMessage = string.Empty;
            return result;
        }

        private bool isStockValid(StockModel stock)
        {
            if (stock.WithdrawnAmount > stock.CurrentAmount) return false;

            return true;
        }
        #endregion


        #region Button clicks
        public void ConfirmButton()
        {
            Confirm();
        }

        public void StockItemClick(StockModel stock)
        {
            AddSelectedStock(stock);
        }
        #endregion
    }
}
