using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Infragistics.Themes;
using PFConsole.Logs;

namespace PFConsole
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static ISplashScreen splashScreen;

        private ManualResetEvent ResetSplashCreated;
        private Thread SplashThread;

        protected override void OnStartup(StartupEventArgs e)
        {
            Logger.Instance.Log("App Executed...");

            ThemeManager.ApplicationTheme = new Office2013Theme();
            Logger.Instance.Log("Theme Loaded.");

            ResetSplashCreated = new ManualResetEvent(false);

            SplashThread = new Thread(ShowSplash);
            SplashThread.SetApartmentState(ApartmentState.STA);
            SplashThread.IsBackground = true;
            SplashThread.Name = "Splash Screen";
            SplashThread.Start();

            ResetSplashCreated.WaitOne();
            base.OnStartup(e);
        }

        private void ShowSplash()
        {
            SplashWindow animatedSplashScreenWindow = new SplashWindow();
            splashScreen = animatedSplashScreenWindow;

            animatedSplashScreenWindow.Show();

            ResetSplashCreated.Set();
            Dispatcher.Run();
        }
    }
}