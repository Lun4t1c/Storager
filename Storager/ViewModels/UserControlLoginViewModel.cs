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

        private string _lastLoginMessage = "";
        public string LastLoginMessage
        {
            get { return _lastLoginMessage; }
            set { _lastLoginMessage = value; NotifyOfPropertyChange(() => LastLoginMessage); }
        }

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
            UserModel userModel;

            switch (DataAcces.CheckCredentials(UserLogin, SecurePassword))
            {
                case Enums.LoginResultCodesEnum.OK:
                    userModel = DataAcces.GetUser(UserLogin, SecurePassword);
                    LastLoginMessage = "Logging in...";
                    break;

                case Enums.LoginResultCodesEnum.INVALID_LOGIN:
                    LastLoginMessage = "Invalid login.";
                    return;

                case Enums.LoginResultCodesEnum.INVALID_PASSWORD:
                    LastLoginMessage = "Invalid password";
                    return;

                case Enums.LoginResultCodesEnum.LOGIN_FAILED:
                    LastLoginMessage = "Login failed";
                    return;

                default:
                    return;
            }

            userModel = DataAcces.GetUser(UserLogin, SecurePassword);
        }
        #endregion

        #region Button clicks
        public void ExitButton()
        {
            Environment.Exit(1);
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
