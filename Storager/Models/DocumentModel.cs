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
        public int Id_DocumentType { get; set; }
        #endregion


        #region Properties
        public IEnumerable<StockModel> Stocks { get; set; }

        private DocumentTypeModel _documentType = null;

        public DocumentTypeModel DocumentType
        {
            get
            {
                if (_documentType != null)
                    return _documentType;
                else
                {
                    _documentType = DataAcces.GetSingleDocumentType(Id_DocumentType);
                    return _documentType;
                }
            }
            set { _documentType = value; }
        }
        #endregion
    }
}
