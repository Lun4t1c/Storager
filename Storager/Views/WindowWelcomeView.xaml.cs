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
using System.Windows.Shapes;

namespace Storager.Views
{
    /// <summary>
    /// Interaction logic for WindowWelcomeView.xaml
    /// </summary>
    public partial class WindowWelcomeView : Window
    {
        public WindowWelcomeView()
        {
            InitializeComponent();
            AnimateWindowIn();
            StartAnimatingBorderBackground();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #region Animations
        private void AnimateWindowIn()
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation anim = new DoubleAnimation()
            {
                DecelerationRatio = 0.7f,
                Duration = new Duration(TimeSpan.FromMilliseconds(1000)),
                From = 0,
                To = 1
            };
            Storyboard.SetTargetProperty(anim, new PropertyPath("Opacity"));
            sb.Children.Add(anim);

            sb.Begin(this);
        }

        private void StartAnimatingBorderBackground()
        {
            Storyboard sb = new Storyboard();

            DoubleAnimation anim1 = new DoubleAnimation()
            {
                AccelerationRatio = 0.8f,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                From = 0,
                To = 1,
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            Storyboard.SetTargetName(anim1, "GradientStop1");
            Storyboard.SetTargetProperty(anim1, new PropertyPath(GradientStop.OffsetProperty));
            sb.Children.Add(anim1);

            sb.Begin(MainBorder);
        }
        #endregion
    }
}
