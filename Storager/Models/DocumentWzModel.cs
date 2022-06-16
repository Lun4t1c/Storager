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
        public int Id_Recipent { get; set; }
        #endregion


        #region Other properties
        private BindableCollection<ProductAndAmount> _productsAndAmount = null;
        private ContractorModel _recipent = null;

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

        public ContractorModel Recipent
        {
            get
            {
                if (_recipent != null)
                    return _recipent;
                else
                {
                    _recipent = DataAcces.GetSingleContractor(Id_Recipent);
                    return _recipent;
                }
            }
            set { _recipent = value; }
        }
        #endregion
    }
}
