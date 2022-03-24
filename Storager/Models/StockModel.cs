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
        public int IdProduct { get; set; }
        public int IdStorageRack { get; set; }
        #endregion


        #region Methods

        #endregion
    }
}
