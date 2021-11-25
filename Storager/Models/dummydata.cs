using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.Models
{
    public static class dummydata
    {
        #region classes
        public class product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public decimal price { get; set; }
        }
        #endregion

        #region methods
        public static BindableCollection<product> GetProducts()
        {
            BindableCollection<product> OutV = new BindableCollection<product>();

            OutV.Add(new product { id = 1, name = "Goger", description = "Program, ktory szpiega co ty robisz.", price = 10.99M });
            OutV.Add(new product { id = 2, name = "Audi A4", description = "Lorem ipsum bla bla bla....", price = 5000.00M });
            OutV.Add(new product { id = 3, name = "Kokroomicz", description = "Liczy kroki", price = 4.50M });
            OutV.Add(new product { id = 4, name = "Toto", description = "Samochod, nad ktoym prasowalem wonym czasie benc", price = 230.29M });

            return OutV;
        }
        #endregion
    }
}
