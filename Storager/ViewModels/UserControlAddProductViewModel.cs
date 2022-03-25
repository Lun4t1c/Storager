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

        private string _productName = null;
        private string _productDescription = null;
        private string _productBarcode = null;
        private UnitOfMeasureModel _productUnitOfMeasure = null;
        private string _warningMessage = string.Empty;

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

        public string ProductBarcode
        {
            get { return _productBarcode; }
            set { _productBarcode = value; NotifyOfPropertyChange(() => ProductBarcode); }
        }

        public UnitOfMeasureModel ProductUnitOfMeasure
        {
            get { return _productUnitOfMeasure; }
            set { _productUnitOfMeasure = value; NotifyOfPropertyChange(() => ProductUnitOfMeasure); }
        }

        public string WarningMessage
        {
            get { return _warningMessage; }
            set { _warningMessage = value; NotifyOfPropertyChange(() => WarningMessage); }
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
            if (!IsFormValid())
            {
                return;
            }

            ProductModel product = new ProductModel() {
                Name = ProductName,
                Description = ProductDescription,
                Barcode = ProductBarcode,
                Id_UnitOfMeasure = ProductUnitOfMeasure.Id
            };

            /*
            Console.WriteLine("Adding product:");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Desc: {product.Description}");
            Console.WriteLine($"Barc: {product.Barcode}");
            Console.WriteLine($"IDun: {product.IdUnit}");
            */

            DataAcces.InsertProduct(product);
            WarningMessage = "Succesfully added product!";
            ((Conductor<object>)Parent).ActivateItemAsync(new UserControlProductsViewModel());
        }

        private bool IsFormValid()
        {
            bool result = true;
            WarningMessage = "";

            if (string.IsNullOrEmpty(ProductName))
            {
                WarningMessage += "Name cannot be empty\n";
                result = false;
            }

            if (ProductUnitOfMeasure == null)
            {
                WarningMessage += "Unit of measure cannot be empty\n";
                result = false;
            }

            return result;
        }
        #endregion


        #region Button clicks
        public void ConfirmButton()
        {
            Confirm();
        }
        #endregion
    }
}
