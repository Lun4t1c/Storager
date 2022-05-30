using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class ProductAndAmount
    {
        #region Properties
        public ProductModel Product { get; set; }
        public int Amount { get; set; }
        #endregion

        #region Constructor
        public ProductAndAmount(ProductModel product, int amount)
        {
            Product = product;
            Amount = amount;
        }
        #endregion
    }
}
