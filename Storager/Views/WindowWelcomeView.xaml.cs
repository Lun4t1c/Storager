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
            StartAnimatingBorderBackgroundStartPoint();
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

        private void StartAnimatingBorderBackgroundOffset()
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

        private void StartAnimatingBorderBackgroundStartPoint()
        {
            Storyboard sb = new Storyboard();

            #region Anim1
            PointAnimationUsingKeyFrames anim1 = new PointAnimationUsingKeyFrames()
            {

                Duration = new Duration(TimeSpan.FromSeconds(10)),
                AutoReverse = false,
                RepeatBehavior = RepeatBehavior.Forever
            };

            anim1.KeyFrames.Add(new LinearPointKeyFrame()
            {
                Value = new Point(1, 0),

            });
            anim1.KeyFrames.Add(new LinearPointKeyFrame()
            {
                Value = new Point(1, 1),

            });
            anim1.KeyFrames.Add(new LinearPointKeyFrame()
            {
                Value = new Point(0, 1),

            });
            anim1.KeyFrames.Add(new LinearPointKeyFrame()
            {
                Value = new Point(0, 0),

            });

            Storyboard.SetTargetName(anim1, "BorderLGB");
            Storyboard.SetTargetProperty(anim1, new PropertyPath(LinearGradientBrush.StartPointProperty));
            sb.Children.Add(anim1);
            #endregion

            #region anim2
            PointAnimationUsingKeyFrames anim2 = new PointAnimationUsingKeyFrames()
            {

                Duration = new Duration(TimeSpan.FromSeconds(10)),
                AutoReverse = false,
                RepeatBehavior = RepeatBehavior.Forever
            };

            anim2.KeyFrames.Add(new LinearPointKeyFrame()
            {
                Value = new Point(0, 1),

            });
            anim2.KeyFrames.Add(new LinearPointKeyFrame()
            {
                Value = new Point(0, 0),

            });
            anim2.KeyFrames.Add(new LinearPointKeyFrame()
            {
                Value = new Point(1, 0),

            });
            anim2.KeyFrames.Add(new LinearPointKeyFrame()
            {
                Value = new Point(1, 1),

            });

            Storyboard.SetTargetName(anim2, "BorderLGB");
            Storyboard.SetTargetProperty(anim2, new PropertyPath(LinearGradientBrush.EndPointProperty));
            sb.Children.Add(anim2);
            #endregion

            sb.Begin(MainBorder);
        }
        #endregion
    }
}
