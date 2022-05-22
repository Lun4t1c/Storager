using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class DocumentBaseModel
    {
        #region Database columns
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DateOfSigning { get; set; }
        public int Id_ApprovedBy { get; set; }
        public string InvoiceNumber { get; set; }
        #endregion


        #region Methods

        #endregion
    }
}
