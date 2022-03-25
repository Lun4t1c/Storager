using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class DocumentModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Supplier { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateOfSigning { get; set; }
        #endregion


        #region Properties
        public IEnumerable<StockModel> Stocks { get; set; }
        #endregion
    }
}
