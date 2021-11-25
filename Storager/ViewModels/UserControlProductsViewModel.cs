using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlProductsViewModel : Screen
    {
        #region Properties
        private BindableCollection<Models.dummydata.product> _products;
        public BindableCollection<Models.dummydata.product> Products
        {
            get { return _products; }
            set { _products = value; NotifyOfPropertyChange(() => Products); }
        }

        #endregion

        #region Constructor
        public UserControlProductsViewModel()
        {
            Products = Models.dummydata.GetProducts();

            foreach (var item in Products)
            {
                Console.WriteLine($"{item.id} - {item.name} - {item.description}");
            }
        }
        #endregion

        #region Methods

        #endregion
    }
}
