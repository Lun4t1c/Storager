using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Storager.Models
{
    public class DocumentPzModel : DocumentBaseModel
    {
        #region Database columns
        public string Supplier { get; set; }
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
                    _stocks = DataAcces.GetStocksInDocumentPz(this);
                    return _stocks;
                }
            }
            set { _stocks = value; }
        }
        #endregion
    }
}
