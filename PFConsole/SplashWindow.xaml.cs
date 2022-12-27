using System;
using System.Windows;
using System.Windows.Input;

namespace PFConsole
{
    public partial class SplashWindow : Window, ISplashScreen
    {
        public SplashWindow()
        {
            InitializeComponent();
        }

        public void AddMessage(string message)
        {
            Dispatcher.Invoke((Action) delegate { _LoadingText.Text = message; });
        }

        public void LoadComplete()
        {
            Dispatcher.InvokeShutdown();
        }

        private void _CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(67);
        }

        private void LayoutRoot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }

    public interface ISplashScreen
    {
        void AddMessage(string message);
        void LoadComplete();
    }
}