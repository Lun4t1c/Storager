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

        public static void InsertRandomValuesToDatabase()
        {

        }

        public static IEnumerable<ProductModel> GenerateRandomProducts()
        {
            IEnumerable<ProductModel> OutV = new List<ProductModel>();



            return OutV;
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
            "mud",
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
