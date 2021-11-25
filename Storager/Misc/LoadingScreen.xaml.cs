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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Storager.Misc
{
    /// <summary>
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : UserControl
    {
        public LoadingScreen()
        {
            InitializeComponent();
            BeginAnimation();
        }

        #region Animations
        private void BeginAnimation()
        {
            Storyboard sb = new Storyboard();

            DoubleAnimation anim1 = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                From = 0,
                To = 1,
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            Storyboard.SetTargetName(anim1, "GradientStop1");
            Storyboard.SetTargetProperty(anim1, new PropertyPath(GradientStop.OffsetProperty));
            sb.Children.Add(anim1);

            sb.Begin(LoadingBarRectangle);
        }
        #endregion
    }
}
