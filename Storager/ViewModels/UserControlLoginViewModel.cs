using Caliburn.Micro;
using Storager.Models;
using Storager.Views;
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
        private string _userLogin;
        private string _userPassword;
        public System.Security.SecureString SecurePassword { private get; set; }
        private string _lastLoginMessage = "";

        public string LastLoginMessage
        {
            get { return _lastLoginMessage; }
            set { _lastLoginMessage = value; NotifyOfPropertyChange(() => LastLoginMessage); }
        }
        
        public string UserLogin
        {
            get { return _userLogin; }
            set { _userLogin = value; NotifyOfPropertyChange(() => UserLogin); }
        }
        
        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; NotifyOfPropertyChange(() => UserPassword); }
        }
        #endregion

        #region Constructor
        public UserControlLoginViewModel()
        {
            //StartUpMainShell(null);
            //System.Windows.Window.GetWindow((System.Windows.Controls.UserControl)this.GetView()).Close();
        }
        #endregion

        #region Methods
        private void StartUpMainShell()
        {
            IWindowManager manager = new WindowManager();
            manager.ShowWindowAsync(new ViewModels.WindowShellViewModel());
        }

        [Obsolete]
        private void LogIn()
        {
            UserModel userModel;

            switch (DataAcces.CheckCredentials(UserLogin, SecurePassword))
            {
                case Enums.eLoginResultCodes.OK:
                    Globals.LoggedUser = DataAcces.GetUser(UserLogin, SecurePassword);
                    LastLoginMessage = "Logging in...";
                    break;

                case Enums.eLoginResultCodes.INVALID_LOGIN:
                    LastLoginMessage = "Invalid login.";
                    return;

                case Enums.eLoginResultCodes.INVALID_PASSWORD:
                    LastLoginMessage = "Invalid password";
                    return;

                case Enums.eLoginResultCodes.LOGIN_FAILED:
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
            //Improve loading animation
            Globals.windowWelcomeView.StartLoadingAnimation();
            UserModel userModel;

            Enums.eLoginResultCodes result = await Task.Run( () => DataAcces.CheckCredentials(UserLogin, SecurePassword) );

            switch (result)
            {
                case Enums.eLoginResultCodes.OK:                    
                    LastLoginMessage = "Logging in...";
                    Globals.LoggedUser = await Task.Run( () => DataAcces.GetUser(UserLogin, SecurePassword) );


                    //Finds and closes WindowWelcomeView after succesfuly logging in
                    var window = System.Windows.Window.GetWindow((System.Windows.Controls.UserControl)this.GetView());

                    await Task.Run(() => System.Threading.Thread.Sleep(1000));
                    window.Close();

                    StartUpMainShell();
                    break;

                case Enums.eLoginResultCodes.INVALID_LOGIN:
                    LastLoginMessage = "Invalid login.";
                    return;

                case Enums.eLoginResultCodes.INVALID_PASSWORD:
                    LastLoginMessage = "Invalid password";
                    return;

                case Enums.eLoginResultCodes.LOGIN_FAILED:
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
