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
        public int Id_Supplier { get; set; }
        #endregion


        #region Other properties
        private BindableCollection<StockModel> _stocks = null;
        private ContractorModel _supplier = null;

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

        public ContractorModel Supplier
        {
            get
            {
                if (_supplier != null)
                    return _supplier;
                else
                {
                    _supplier = DataAcces.GetSingleContractor(Id_Supplier);
                    return _supplier;
                }
            }
            set { _supplier = value; }
        }

        #endregion
    }
}
