using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class ProductModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerUnit { get; set; }

        #endregion

        #region Constructor
        public ProductModel()
        {

        }
        #endregion

        #region Methods

        #endregion
    }
}
