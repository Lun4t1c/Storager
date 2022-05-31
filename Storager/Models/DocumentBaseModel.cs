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

        #region Other properties
        private string _approvedBy = null;

        public string ApprovedBy
        {
            get 
            {
                if (_approvedBy != null)
                    return _approvedBy;
                else
                {
                    _approvedBy = DataAcces.GetUserLogin(Id_ApprovedBy);
                    return _approvedBy;
                }
            }
            set { ApprovedBy = value; }
        }

        #endregion

        #region Methods

        #endregion
    }
}
