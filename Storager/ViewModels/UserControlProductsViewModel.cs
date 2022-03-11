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
        private BindableCollection<Models.dummydata.product> _filteredProducts;
        private string _filterString;


        public BindableCollection<Models.dummydata.product> Products
        {
            get { return _products; }
            set { _products = value; NotifyOfPropertyChange(() => Products); }
        }

        public BindableCollection<Models.dummydata.product> FilteredProducts
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
            Products = Models.dummydata.GetProducts();
            FilteredProducts = new BindableCollection<Models.dummydata.product>(Products);
            cwlist();
        }
        #endregion

        #region Methods
        private void FilterProducts()
        {
            if (FilterString == "" || FilterString == null)
                FilteredProducts = new BindableCollection<Models.dummydata.product>(Products);
            else
            {
                FilteredProducts.Clear();
                List<Models.dummydata.product> tempList = Products.Where(pr => pr.name.Contains(FilterString)).ToList();
                foreach (var p in tempList)
                    FilteredProducts.Add(p);
            }

            cwlist();
        }
        #endregion

        private void cwlist()
        {
            Console.WriteLine("cwing list:");
            foreach (var item in FilteredProducts)
            {
                Console.WriteLine($"-{item.name}");
                Console.WriteLine();
            }
        }
    }
}
