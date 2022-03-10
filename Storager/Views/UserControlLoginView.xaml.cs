using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Storager.Views
{
    /// <summary>
    /// Interaction logic for UserControlLoginView.xaml
    /// </summary>
    public partial class UserControlLoginView : UserControl
    {
        #region Constructor
        public UserControlLoginView()
        {
            InitializeComponent();
            Loaded += UserControlLoginView_Loaded;
        }

        private void UserControlLoginView_Loaded(object sender, RoutedEventArgs e)
        {
            UserLogin.Focus();
        }
        #endregion

        #region Methods
        private void SecurePassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword; }
        }
        #endregion
    }
}
