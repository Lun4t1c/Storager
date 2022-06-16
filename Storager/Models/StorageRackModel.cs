using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class StorageRackModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Code { get; set; }
        #endregion

        #region Other properties
        private BindableCollection<StockModel> _stocks = null;

        public BindableCollection<StockModel> Stocks
        {
            get
            {
                if (_stocks != null)
                    return _stocks;
                else
                {
                    _stocks = DataAcces.GetStocksInStorageRack(this);
                    return _stocks;
                }
            }
            set { _stocks = value; }
        }

        #endregion
    }
}
