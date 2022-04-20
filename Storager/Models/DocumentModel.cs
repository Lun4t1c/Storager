using Caliburn.Micro;
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
        private DocumentTypeModel _documentType = null;
        private BindableCollection<StockModel> _stocks = null;

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

        public BindableCollection<StockModel> Stocks
        {
            get
            {
                if (_stocks != null)
                    return _stocks;
                else
                {
                    _stocks = DataAcces.GetStocksInDocument(this);
                    return _stocks;
                }
            }
            set { _stocks = value; }
        }
        #endregion
    }
}
