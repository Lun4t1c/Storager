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
using System.Windows.Shapes;

namespace Storager.Views
{
    /// <summary>
    /// Interaction logic for WindowDocumentInspectorView.xaml
    /// </summary>
    public partial class WindowDocumentInspectorView : Window
    {
        public WindowDocumentInspectorView()
        {
            InitializeComponent();
        }

        private void SecurePassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).UserPassword = ((PasswordBox)sender).SecurePassword; }
        }
    }
}
