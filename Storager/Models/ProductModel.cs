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
        public string Barcode { get; set; }
        public int IdUnit { get; set; }
        #endregion


        #region Methods

        #endregion
    }
}
