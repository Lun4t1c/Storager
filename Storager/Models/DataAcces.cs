using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Dapper;
using Storager.Enums;

namespace Storager.Models
{
    public static class DataAcces
    {
        #region Get data
        private static bool CheckPassword(string login, SecureString password)
        {
            string s = new System.Net.NetworkCredential(string.Empty, password).Password;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                byte[] bytes = Encoding.Unicode.GetBytes(s);
                SHA256Managed hashstring = new SHA256Managed();
                byte[] hash = hashstring.ComputeHash(bytes);
                string hashString = string.Empty;
                foreach (byte x in hash)
                {
                    hashString += String.Format("{0:x2}", x);
                }
                
                string tempPass = connection.QuerySingleOrDefault<string>("select HashedPassword from ACCOUNTS WHERE Login = @lg", new { lg = login });
                Console.WriteLine($"HASH - {hashString}\nTEMP - {tempPass}");

                if (hashString == tempPass)
                    return true;
                else
                    return false;
            }
        }

        public static eLoginResultCodes CheckCredentials(string login, SecureString password)
        {
            if (!CheckPassword(login, password))
                return eLoginResultCodes.INVALID_PASSWORD;

            return eLoginResultCodes.OK;
        }

        public static UserModel GetUser(string login, SecureString password)
        {
            if (!CheckPassword(login, password))
                return null;

            UserModel OutV = null;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                UserModel temp = connection.QuerySingleOrDefault<UserModel>("select * from ACCOUNTS WHERE Login = @lg", new { lg = login });
                OutV = temp;
            }
            return OutV;
        }
        

        public static BindableCollection<UnitOfMeasureModel> GetAllUnitsOfMeasure()
        {
            IEnumerable<UnitOfMeasureModel> units = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                units = connection.Query<UnitOfMeasureModel>($"SELECT * FROM UNITS_OF_MEASURE");
            }

            return new BindableCollection<UnitOfMeasureModel>(units);
        }
        
        public static BindableCollection<ProductModel> GetAllProducts()
        {
            IEnumerable<ProductModel> products = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                products = connection.Query<ProductModel>($"SELECT * FROM PRODUCTS");
            }

            return new BindableCollection<ProductModel>(products);
        }

        public static BindableCollection<DocumentTypeModel> GetAllDocumentTypes()
        {
            IEnumerable<DocumentTypeModel> documents = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                documents = connection.Query<DocumentTypeModel>($"SELECT * FROM DOCUMENT_TYPES");
            }

            return new BindableCollection<DocumentTypeModel>(documents);
        }

        public static BindableCollection<StorageRackModel> GetAllStorageRacks()
        {
            IEnumerable<StorageRackModel> racks = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                racks = connection.Query<StorageRackModel>($"SELECT * FROM STORAGE_RACKS");
            }

            foreach (var rack in racks)
            {
                Console.WriteLine($"-{rack.Code}");
            }
            return new BindableCollection<StorageRackModel>(racks);
        }
        
        public static BindableCollection<StockModel> GetStocksInDocument(DocumentModel document)
        {
            throw new NotImplementedException();
        }

        public static ProductModel GetSingleProduct(int id_product)
        {
            ProductModel product = null;

            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                product = connection.QuerySingleOrDefault<ProductModel>($"SELECT * FROM PRODUCTS WHERE Id = @id", 
                    new { @id = id_product });
            }

            return product;
        }

        public static StorageRackModel GetSingleStorageRack(int id_rack)
        {
            StorageRackModel rack = null;

            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                rack = connection.QuerySingleOrDefault<StorageRackModel>($"SELECT * FROM STORAGE_RACKS WHERE Id = @id",
                    new { @id = id_rack });
            }

            return rack;
        }
        #endregion


        #region Insert data
        /// <summary>
        /// Register new user in database
        /// </summary>
        /// <param name="login"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="id_privilege"></param>
        /// <returns></returns>
        public static int RegisterUser(string login, string email, string password, int id_privilege)
        {            
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute("INSERT INTO ACCOUNTS(Email, Login, HashedPassword, Id_privilege) VALUES(@em, @lg, @hp, @idp)",
                    new { em = email, lg = login, hp = hashString, idp = id_privilege }
                );
            }

            return 0;
        }
        
        /// <summary>
        /// Insert product into database using stored procedure
        /// </summary>
        /// <param name="product">Product to insert</param>
        public static void InsertProduct(ProductModel product)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertProduct", connection) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = product.Name;
                    cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = product.Description;
                    cmd.Parameters.Add("@barcode", SqlDbType.NVarChar).Value = product.Barcode;
                    cmd.Parameters.Add("@id_unit_of_measure", SqlDbType.TinyInt).Value = product.Id_UnitOfMeasure;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Insert document into database using stored procedure
        /// </summary>
        /// <param name="document">Document to insert</param>
        public static void InsertDocument(DocumentModel document)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
