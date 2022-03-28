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

        public static BindableCollection<DocumentTypeModel> GetDocuments()
        {
            BindableCollection<DocumentTypeModel> OutV = new BindableCollection<DocumentTypeModel>();

            OutV.Add(new DocumentTypeModel() { FullName = "Benc" });
            OutV.Add(new DocumentTypeModel() { FullName = "sdfdfdf" });
            OutV.Add(new DocumentTypeModel() { FullName = "sdasd" });
            OutV.Add(new DocumentTypeModel() { FullName = "vbvcbv" });

            return OutV;
        }

        public static IEnumerable<ProductModel> GenerateRandomProducts()
        {
            List<ProductModel> OutV = new List<ProductModel>();
            Random random = new Random();

            var units = DataAcces.GetAllUnitsOfMeasure();
            foreach (var name in GenerateRandomNames())
            {
                OutV.Add(new ProductModel()
                {
                    Name = name,
                    Barcode = random.Next(100000, 999999).ToString(),
                    Description = string.Empty,
                    Id_UnitOfMeasure = units[random.Next(units.Count)].Id
                });
            }

            foreach (ProductModel product in OutV)
            {
                DataAcces.InsertProduct(product);
            }

            return OutV;
        }

        public static void GenerateRandomStocks(int amount)
        {
            BindableCollection<StockModel> stocks = new BindableCollection<StockModel>();
            BindableCollection<ProductModel> products = DataAcces.GetAllProducts();
            BindableCollection<StorageRackModel> storageRacks = DataAcces.GetAllStorageRacks();
            Random random = new Random();

            for (int i = 0; i < amount; i++)
            {
                int temp = random.Next(10, 100);
                stocks.Add(new StockModel()
                {
                    PricePerUnit = (decimal) ((float)random.Next(0,101) + (float)random.Next(0, 99) / 100),
                    Amount = temp,
                    CurrentAmount = random.Next(temp),
                    Id_Product = products[random.Next(products.Count)].Id,
                    Id_StorageRack = storageRacks[random.Next(storageRacks.Count)].Id
                }); 
            }

            foreach (var stock in stocks)
            {
                DataAcces.InsertStock(stock);
            }
        }

        public static IEnumerable<string> GenerateRandomNames()
        {
            List<string> OutV = new List<string>();
            Random random = new Random();

            List<string> adjectives = new List<string>(Adjectives);
            List<string> nouns = new List<string>(Nouns);

            while (adjectives.Count > 0 && nouns.Count > 0)
            {
                int adjInd = random.Next(0, adjectives.Count - 1);
                int nounInd = random.Next(0, nouns.Count - 1);

                string tempName = adjectives[adjInd] + " " + nouns[nounInd];
                OutV.Add(tempName);

                adjectives.RemoveAt(adjInd);
                nouns.RemoveAt(nounInd);
            }           

            return OutV;
        }
        #endregion

        #region Words
        static string[] Adjectives = 
        {
            "toothsome",
            "hollow",
            "vivacious",
            "caring",
            "distinct",
            "peaceful",
            "astonishing",
            "yellow",
            "bulky",
            "parsimonious"
        };

        static string[] Nouns =
        {
            "tentegownik",
            "mug",
            "TV",
            "elevator",
            "doormat",
            "cabinet",
            "desk",
            "apple",
            "bike",
            "computer",
            "book"
        };
        #endregion
    }
}
