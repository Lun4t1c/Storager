using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlLoadingScreenViewModel : Screen
    {
        #region Properties
        private string _loadingText;

        public string LoadingText
        {
            get { return _loadingText; }
            set { _loadingText = value; NotifyOfPropertyChange(() => LoadingText); }
        }

        #endregion

        #region Constructor
        public UserControlLoadingScreenViewModel(string loadingText = "")
        {
            Console.WriteLine($"Loading text: {loadingText}");
            LoadingText = loadingText;
        }
        #endregion

        #region Methods

        #endregion
    }
}
