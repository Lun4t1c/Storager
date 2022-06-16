using Caliburn.Micro;
using Storager.Models;
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
        private BindableCollection<ProductModel> _products = DataAcces.GetAllProducts();
        private BindableCollection<ProductModel> _filteredProducts = DataAcces.GetAllProducts();
        private string _filterString;


        public BindableCollection<ProductModel> Products
        {
            get { return _products; }
            set { _products = value; NotifyOfPropertyChange(() => Products); }
        }

        public BindableCollection<ProductModel> FilteredProducts
        {
            get { return _filteredProducts; }
            set { _filteredProducts = value; NotifyOfPropertyChange(() => FilteredProducts); }
        }

        public string FilterString
        {
            get { return _filterString; }
            set { _filterString = value; NotifyOfPropertyChange(() => FilterString); FilterProducts(); }
        }
        
        #endregion


        #region Constructor
        public UserControlProductsViewModel()
        {

        }
        #endregion


        #region Methods
        private void FilterProducts()
        {
            if (FilterString == "" || FilterString == null)
                FilteredProducts = new BindableCollection<ProductModel>(Products);
            else
            {
                IEnumerable<ProductModel> tempList = 
                    from Product 
                    in Products
                    where Product.Name.ToLower().Contains(FilterString.ToLower())
                        || Product.Description.ToLower().Contains(FilterString.ToLower())
                    select Product;

                FilteredProducts = new BindableCollection<ProductModel>(tempList);
            }
        }
        #endregion


        #region Button clicks

        #endregion
    }
}
