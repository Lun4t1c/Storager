using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class PageLoginViewModel : Screen
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
        public PageLoginViewModel()
        {
            Console.WriteLine("dsfsdf");
        }
        #endregion

        #region Methods
        public void ExitButton()
        {
            Console.WriteLine($"Login - {UserLogin}");
            Console.WriteLine($"Password - {UserPassword}");
            Console.WriteLine($"Secure Password - {new System.Net.NetworkCredential(string.Empty, SecurePassword).Password}");
        }
        #endregion
    }
}
