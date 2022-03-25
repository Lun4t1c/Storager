using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class StockModel
    {
        #region Database columns
        public int Id { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Amount { get; set; }
        public int CurrentAmount { get; set; }
        public int Id_Product { get; set; }
        public int Id_StorageRack { get; set; }
        #endregion


        #region Properties
        private ProductModel _product = null;

        public ProductModel Product
        {
            get 
            { 
                if (_product != null)
                    return _product;
                else
                {
                    _product = DataAcces.GetSingleProduct(Id_Product);
                    return _product;
                }
            }
            set { _product = value; }
        }

        #endregion


        #region Methods

        #endregion
    }
}
