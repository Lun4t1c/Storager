using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlLoginViewModel : Screen
    {
        #region Properties

        public System.Security.SecureString SecurePassword { private get; set; }

        private string _userLogin;
        public string UserLogin
        {
            get { return _userLogin; }
            set { _userLogin = value; NotifyOfPropertyChange(() => UserLogin); }
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; NotifyOfPropertyChange(() => UserPassword); }
        }

        #endregion

        #region Constructor
        public UserControlLoginViewModel()
        {

        }
        #endregion

        #region Methods
        private void LogIn()
        {
            UserModel userModel = DataAcces.GetUser(UserLogin, SecurePassword);
            
            if (userModel == null)
            {
                Console.WriteLine("Login failed");
            }
            else
            {
                Console.WriteLine($"Welcome {userModel.Login} - {userModel.Email}");
            }
        }
        #endregion

        #region Button clicks
        public void ExitButton()
        {
            Console.WriteLine($"Login - {UserLogin}");
            Console.WriteLine($"Password - {UserPassword}");
            Console.WriteLine($"Secure Password - {new System.Net.NetworkCredential(string.Empty, SecurePassword).Password}");
        }
        #endregion

        #region Key input
        public void LoginPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                LogIn();
            }
        }
        #endregion
    }
}
