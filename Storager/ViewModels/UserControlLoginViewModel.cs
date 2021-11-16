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
        private void StartUpMainShell(UserModel userModel)
        {
            IWindowManager manager = new WindowManager();
            manager.ShowWindowAsync(new ViewModels.WindowShellViewModel(userModel));
        }

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

        private async Task LogInAsync()
        {
            LastLoginMessage = "Checking credentials...";

            UserModel userModel;

            Enums.LoginResultCodesEnum result = await Task.Run( () => DataAcces.CheckCredentials(UserLogin, SecurePassword) );

            switch (result)
            {
                case Enums.LoginResultCodesEnum.OK:                    
                    LastLoginMessage = "Logging in...";
                    userModel = await Task.Run( () => DataAcces.GetUser(UserLogin, SecurePassword) );
                    

                    //Finds and closes WindowWelcomeView after succesfuly logging in
                    var window = System.Windows.Window.GetWindow((System.Windows.Controls.UserControl)this.GetView());
                    window.Close();

                    StartUpMainShell(userModel);
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
        }
        #endregion

        #region Button clicks
        public void ExitButton()
        {
            Environment.Exit(1);
        }

        public void LoginButton()
        {
            LogInAsync();
        }
        #endregion

        #region Key input
        public void LoginPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                LogInAsync();
            }
        }
        #endregion
    }
}
