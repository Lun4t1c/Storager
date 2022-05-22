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

        public static BindableCollection<DocumentModel> GetAllDocuments()
        {
            IEnumerable<DocumentModel> documents = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                documents = connection.Query<DocumentModel>($"SELECT * FROM DOCUMENTS");

                foreach (DocumentModel doc in documents)
                {
                    doc.Stocks = GetStocksInDocument(doc);
                }
            }

            return new BindableCollection<DocumentModel>(documents);
        }

        public static BindableCollection<DocumentPzModel> GetAllDocumentsPz()
        {
            IEnumerable<DocumentPzModel> documents_pz = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                documents_pz = connection.Query<DocumentPzModel>($"SELECT * FROM DOCUMENTS_PZ");

                foreach (DocumentPzModel doc in documents_pz)
                {
                    doc.Stocks = GetStocksInDocumentPz(doc);
                }
            }

            return new BindableCollection<DocumentPzModel>(documents_pz);
        }

        public static BindableCollection<DocumentWzModel> GetAllDocumentsWz()
        {
            IEnumerable<DocumentWzModel> documents_wz = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                documents_wz = connection.Query<DocumentWzModel>($"SELECT * FROM DOCUMENTS_WZ");

                foreach (DocumentWzModel doc in documents_wz)
                {
                    doc.Products = GetProductsInDocumentWz(doc);
                }
            }

            return new BindableCollection<DocumentWzModel>(documents_wz);
        }

        public static BindableCollection<StockModel> GetAllStocks()
        {
            IEnumerable<StockModel> stocks = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                stocks = connection.Query<StockModel>($"SELECT * FROM STOCKS");
            }

            return new BindableCollection<StockModel>(stocks);
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
            IEnumerable<StockModel> stocks = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                stocks = connection.Query<StockModel>($"SELECT * FROM DOCUMENT_STOCKS ds " +
                    $"JOIN STOCKS s ON ds.Id_stock = s.Id " +
                    $"WHERE ds.Id_document = @id_doc",
                    new { @id_doc = document.Id }
                );
            }

            return new BindableCollection<StockModel>(stocks);
        }

        public static BindableCollection<StockModel> GetStocksInDocumentPz(DocumentPzModel document_pz)
        {
            IEnumerable<StockModel> stocks = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                stocks = connection.Query<StockModel>($"SELECT * FROM DOCUMENT_PZ_STOCKS ds " +
                    $"JOIN STOCKS s ON ds.Id_stock = s.Id " +
                    $"WHERE ds.Id_documentPz = @id_doc",
                    new { @id_doc = document_pz.Id }
                );
            }

            return new BindableCollection<StockModel>(stocks);
        }

        public static BindableCollection<ProductModel> GetProductsInDocumentWz(DocumentWzModel document_pz)
        {
            IEnumerable<ProductModel> products = null;
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                products = connection.Query<ProductModel>($"SELECT * FROM DOCUMENT_WZ_PRODUCTS ds " +
                    $"JOIN STOCKS s ON ds.Id_stock = s.Id " +
                    $"WHERE ds.Id_documentWz = @id_doc",
                    new { @id_doc = document_pz.Id }
                );
            }

            return new BindableCollection<ProductModel>(products);
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
        
        public static UnitOfMeasureModel GetSingleUnitOfMeasure(int id_unit)
        {
            UnitOfMeasureModel unit = null;

            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                unit = connection.QuerySingleOrDefault<UnitOfMeasureModel>($"SELECT * FROM UNITS_OF_MEASURE WHERE Id = @id",
                    new { @id = id_unit });
            }

            return unit;
        }
        
        public static DocumentTypeModel GetSingleDocumentType(int id_doctype)
        {
            DocumentTypeModel doctype = null;

            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                doctype = connection.QuerySingleOrDefault<DocumentTypeModel>($"SELECT * FROM DOCUMENT_TYPES WHERE Id = @id",
                    new { @id = id_doctype });
            }

            return doctype;
        }
        
        public static int? CountProductAmountLeft(int id_product)
        {
            int? AmountLeft = null;

            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                try
                {
                    AmountLeft = connection.QuerySingleOrDefault<int>($"SELECT SUM(CurrentAmount) FROM STOCKS WHERE Id_Product = @id",
                                new { @id = id_product });
                }
                catch 
                {
                    AmountLeft = 0;
                }
            }
            if (AmountLeft == null) return 0;
            return AmountLeft;
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
        /// Insert stock into database using stored procedure
        /// </summary>
        /// <param name="stock">Stock to insert</param>
        public static void InsertStock(StockModel stock)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertStock", connection) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@price_per_unit", SqlDbType.Money).Value = stock.PricePerUnit;
                    cmd.Parameters.Add("@amount", SqlDbType.Int).Value = stock.Amount;
                    cmd.Parameters.Add("@current_amount", SqlDbType.Int).Value = stock.CurrentAmount;
                    cmd.Parameters.Add("@id_product", SqlDbType.Int).Value = stock.Id_Product;
                    cmd.Parameters.Add("@id_storage_rack", SqlDbType.Int).Value = stock.Id_StorageRack;

                    var Id_stock_param = cmd.Parameters.Add("@id_stock", SqlDbType.Int);
                    Id_stock_param.Direction = ParameterDirection.Output;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Insert document into database by determining document type and calling
        /// appropriate method
        /// </summary>
        /// <param name="document"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void InsertDocument(DocumentModel document)
        {
            switch (document.DocumentType.ShortName)
            {
                case "PZ":
                    InsertDocumentPZ(document);
                    break;

                case "WZ":
                    InsertDocumentWZ(document);
                    break;

                default: throw new ArgumentException("Unknonw document type.");
            }
        }

        /// <summary>
        /// Insert PZ document into database using stored procedure
        /// </summary>
        /// <param name="document">Document to insert</param>
        public static void InsertDocumentPZ(DocumentModel document)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                //document
                using (SqlCommand cmd = new SqlCommand("spInsertDocument", connection) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@supplier", SqlDbType.NVarChar).Value = document.Supplier;
                    cmd.Parameters.Add("@date_of_signing", SqlDbType.DateTime).Value = document.DateOfSigning;
                    cmd.Parameters.Add("@invoice_number", SqlDbType.NVarChar).Value = document.InvoiceNumber;
                    cmd.Parameters.Add("@id_document_type", SqlDbType.Int).Value = document.DocumentType.Id;

                    var Id_document_param = cmd.Parameters.Add("@id_document", SqlDbType.Int);
                    Id_document_param.Direction = ParameterDirection.Output;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    document.Id = (int)Id_document_param.Value;
                }

                //stocks
                foreach (StockModel stock in document.Stocks)
                {
                    int Id_stock;
                    using (SqlCommand cmd = new SqlCommand("spInsertStock", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        cmd.Parameters.Add("@price_per_unit", SqlDbType.Money).Value = stock.PricePerUnit;
                        cmd.Parameters.Add("@amount", SqlDbType.Int).Value = stock.Amount;
                        cmd.Parameters.Add("@current_amount", SqlDbType.Int).Value = stock.CurrentAmount;
                        cmd.Parameters.Add("@id_product", SqlDbType.Int).Value = stock.Product.Id;
                        cmd.Parameters.Add("@id_storage_rack", SqlDbType.Int).Value = stock.StorageRack.Id;

                        var Id_stock_param = cmd.Parameters.Add("@id_stock", SqlDbType.Int);
                        Id_stock_param.Direction = ParameterDirection.Output;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        Id_stock = (int)Id_stock_param.Value;
                        stock.Id = Id_stock;
                    }                    
                }
            }

            foreach (StockModel stock in document.Stocks)
            {
                InsertDocumentStock(document, stock);
            }
        }

        public static void InsertDocumentWZ(DocumentModel document)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add stock to existing document using stored procedure
        /// </summary>
        /// <param name="document"></param>
        /// <param name="stock"></param>
        public static void InsertDocumentStock(DocumentModel document, StockModel stock)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertDocumentStocks", connection) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@id_document", SqlDbType.Int).Value = document.Id;
                    cmd.Parameters.Add("@id_stock", SqlDbType.Int).Value = stock.Id;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion


        #region Update data
        public static void UpdateStockCurrentAmount(StockModel stock, int newAmount)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute(
                    "UPDATE STOCKS " +
                    "SET CurrentAmount = @na " +
                    "WHERE Id = @id",
                    new { id = stock.Id, na = newAmount });
            }
        }
        #endregion


        #region Delete data
        public static void DeleteAllDocumentsData()
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteAllDocumentsData", connection) { CommandType = CommandType.StoredProcedure })
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteAllProductsData()
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteAllProductsData", connection) { CommandType = CommandType.StoredProcedure })
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteAllStocksData()
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteAllStocksData", connection) { CommandType = CommandType.StoredProcedure })
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
