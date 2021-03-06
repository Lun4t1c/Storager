using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public class ProductModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public int Id_UnitOfMeasure { get; set; }
        #endregion


        #region Other properties
        private UnitOfMeasureModel _unitOfMeasure = null;
        private int? _amountLeft = null;

        public UnitOfMeasureModel UnitOfMeasure
        {
            get
            {
                if (_unitOfMeasure != null)
                    return _unitOfMeasure;
                else
                {
                    _unitOfMeasure = DataAcces.GetSingleUnitOfMeasure(Id_UnitOfMeasure);
                    return _unitOfMeasure;
                }
            }
            set { _unitOfMeasure = value; }
        }

        public int? AmountLeft
        {
            get
            {
                if (_amountLeft != null)
                    return _amountLeft;
                else
                {
                    _amountLeft = DataAcces.CountProductAmountLeft(Id);
                    return _amountLeft;
                }
            }
            set { _amountLeft = value; }
        }
        #endregion


        #region Methods

        #endregion
    }
}
