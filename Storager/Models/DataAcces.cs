using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using Storager.Enums;

namespace Storager.Models
{
    public static class DataAcces
    {
        #region Getting data with Dapper
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
        #endregion

        #region Inserting data With Dapper
        public static int RegisterUser(string login, string email, string password)
        {
            Console.WriteLine($"Registering user - {login} - {email} - {password}");
            
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


                connection.Execute("INSERT INTO ACCOUNTS(Email, Login, HashedPassword) VALUES(@em, @lg, @hp)",
                    new { em = email, lg = login, hp = hashString }
                    );

            }

            return 0;
        }
        #endregion

        #region Deleting data with Dapper

        #endregion
    }
}
