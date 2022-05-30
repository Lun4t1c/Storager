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
        public string Recipent { get; set; }
        #endregion


        #region Other properties
        private BindableCollection<ProductAndAmount> _productsAndAmount = null;

        public BindableCollection<ProductAndAmount> ProductsAndAmount
        {
            get 
            {
                if (_productsAndAmount != null)
                    return _productsAndAmount;
                else
                {
                    _productsAndAmount = DataAcces.GetProductsAndAmountsInDocumentWz(this);
                    return _productsAndAmount;
                }
            }
            set { _productsAndAmount = value; }
        }
        #endregion
    }
}
