using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class WindowDocumentInspectorViewModel : Screen
    {
        #region Properties
        private DocumentBaseModel _document;
        private BindableCollection<StockModel> _stocks = null;
        private BindableCollection<ProductAndAmount> _productsAndAmounts;

        public DocumentBaseModel Document
        {
            get { return _document; }
            set { _document = value; NotifyOfPropertyChange(() => Document); }
        }

        public BindableCollection<StockModel> Stocks
        {
            get { return _stocks; }
            set { _stocks = value; NotifyOfPropertyChange(() => Stocks); }
        }        

        public BindableCollection<ProductAndAmount> ProductsAndAmounts
        {
            get { return _productsAndAmounts; }
            set { _productsAndAmounts = value; NotifyOfPropertyChange(() => ProductsAndAmounts); }
        }


        public string RecipentSupplierString
        {
            get 
            {
                if (Document.GetType() == typeof(DocumentPzModel)) return ((DocumentPzModel)Document).Supplier;
                if (Document.GetType() == typeof(DocumentWzModel)) return ((DocumentWzModel)Document).Recipent;
                return null;
            }
        }

        public string RecipentSupplier
        {
            get
            {
                if (Document.GetType() == typeof(DocumentPzModel)) return "Supplier";
                if (Document.GetType() == typeof(DocumentWzModel)) return "Recipent";
                return null;
            }
        }

        #endregion

        #region Constructor
        public WindowDocumentInspectorViewModel(DocumentBaseModel document)
        {
            Document = document;
            LoadStocksOrProducts();
        }
        #endregion

        #region Methods
        private void LoadStocksOrProducts()
        {
            if (Document.GetType() == typeof(DocumentPzModel))
            {
                Console.WriteLine("LOADING STOCKS");
                ProductsAndAmounts = null;
                Stocks = ((DocumentPzModel)Document).Stocks;
            }
            else if (Document.GetType() == typeof(DocumentWzModel))
            {
                Console.WriteLine("LOADING PRODUCTS");
                Stocks = null;
                ProductsAndAmounts = ((DocumentWzModel)Document).ProductsAndAmount;

                foreach (var x in ((DocumentWzModel)Document).ProductsAndAmount)
                {
                    Console.WriteLine("BLERG");
                }
            }
        }
        #endregion
    }
}
