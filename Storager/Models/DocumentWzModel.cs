using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Storager.Models
{
    public class DocumentWzModel : DocumentBaseModel
    {
        #region Database columns
        public int Recipent { get; set; }
        #endregion


        #region Other properties
        private BindableCollection<ProductModel> _products = null;

        public BindableCollection<ProductModel> Products
        {
            get 
            {
                if (_products != null)
                    return _products;
                else
                {
                    _products = DataAcces.GetProductsInDocumentWz(this);
                    return _products;
                }
            }
            set { _products = value; }
        }
        #endregion
    }
}
