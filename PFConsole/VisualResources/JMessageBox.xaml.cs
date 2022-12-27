using System;
using System.Windows;
using System.Windows.Controls;

namespace PFConsole.VisualResources
{
    /// <summary>
    ///     Interaction logic for JMessageBox.xaml
    /// </summary>
    public partial class JMessageBox
    {
        protected MessageBoxResult Result { get; private set; }

        protected JMessageBox()
        {
            InitializeComponent();
        }

        public static MessageBoxResult Show(string message, string title, MessageBoxButton buttons, MessageBoxImage image, MessageBoxOptions options)
        {
            JMessageBox box = new JMessageBox();

            box.Title = title;
            box._textblock.Text = message;
            box.GoToState(buttons);
            //img
            //options

            box.ShowDialog();
            return box.Result;
        }

        public static MessageBoxResult Show(string message, string title, MessageBoxButton buttons, MessageBoxImage image)
        {
            return Show(message, title, buttons, MessageBoxImage.None, MessageBoxOptions.None);
        }

        public static MessageBoxResult Show(string message, string title, MessageBoxButton buttons)
        {
            return Show(message, title, buttons, MessageBoxImage.None, MessageBoxOptions.None);
        }

        public static MessageBoxResult Show(string message)
        {
            return Show(message, "Message", MessageBoxButton.OK);
        }

        private void GoToState(MessageBoxButton buttons)
        {
            switch (buttons)
            {
                case MessageBoxButton.OK:
                    break;
                case MessageBoxButton.OKCancel:
                    VisualStateManager.GoToElementState(LayoutRoot, "OKCancel", false);
                    break;
                case MessageBoxButton.YesNoCancel:
                    VisualStateManager.GoToElementState(LayoutRoot, "YesNoCancel", false);
                    break;
                case MessageBoxButton.YesNo:
                    VisualStateManager.GoToElementState(LayoutRoot, "YesNo", false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("buttons");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = (sender as Button).Tag as MessageBoxResult?;
            Result = result.GetValueOrDefault();

            Close();
        }
    }
}