using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlAddProductViewModel : Screen
    {
        #region Properties
        public BindableCollection<UnitOfMeasureModel> UnitsOfMeasure { get; set; } = DataAcces.GetAllUnitsOfMeasure();

        private string _productName;
        private string _productDescription = null;
        private decimal _productPricePerUnit;

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; NotifyOfPropertyChange(() => ProductName); }
        }        

        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; NotifyOfPropertyChange(() => ProductDescription); }
        }        

        public decimal ProductPricePerUnit
        {
            get { return _productPricePerUnit; }
            set { _productPricePerUnit = value; NotifyOfPropertyChange(() => ProductPricePerUnit); }
        }

        #endregion

        #region Constructor
        public UserControlAddProductViewModel()
        {
            
        }
        #endregion

        #region Methods
        private void Confirm()
        {

        }
        #endregion
    }
}
