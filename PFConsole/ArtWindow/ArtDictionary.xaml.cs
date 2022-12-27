using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ArtWindow
{
    public partial class ArtDictionary : ResourceDictionary
    {
        private void BorderMouseDown(object sender, MouseEventArgs e)
        {
            var border = (sender as Grid).Tag as Border;

            Point point = e.GetPosition(border);

            if (point.X > 0 && point.Y > 0 && point.Y < border.ActualHeight && e.LeftButton == MouseButtonState.Pressed)
                ((sender as Grid).TemplatedParent as Window).DragMove();
        }

        private void MaximizeClick(object sender, EventArgs e)
        {
            var win = (sender as Button).TemplatedParent as Window;

            win.WindowState = win.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void MinimizeClick(object sender, EventArgs e)
        {
            var win = (sender as Button).TemplatedParent as Window;

            win.StateChanged -= WinOnStateChanged;
            win.StateChanged += WinOnStateChanged;

            DoubleAnimation opacityAnimation = new DoubleAnimation(1.0, 0.4, new Duration(TimeSpan.FromSeconds(0.2)));
            opacityAnimation.Completed += (o, args) => { win.WindowState = WindowState.Minimized; };
            opacityAnimation.DecelerationRatio = 0.4;

            win.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
        }

        private void WinOnStateChanged(object sender, EventArgs eventArgs)
        {
            var win = (sender as Window);

            if ((sender as Window).Opacity < 1)
            {
                DoubleAnimation opacityAnimation = new DoubleAnimation(0.4, 1, new Duration(TimeSpan.FromSeconds(0.01)));
                opacityAnimation.DecelerationRatio = 0.4;

                win.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
            }
        }
    }
}