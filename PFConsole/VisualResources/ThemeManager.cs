using System.ComponentModel;
using System.Windows.Media;
using PFConsole.Annotations;

namespace PFConsole.VisualResources
{
    public class ThemeManager : INotifyPropertyChanged
    {
        #region Singleton

        private static ThemeManager _instance;
        private static object _lock = true;

        public static ThemeManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new ThemeManager();

                    return _instance;
                }
            }
        }

        #endregion

        private SolidColorBrush _themeColor;
        private SolidColorBrush _themeAccentColor;
        private SolidColorBrush _themeBackgroundColor;
        private SolidColorBrush _themePageColor = new SolidColorBrush(Color.FromRgb(50, 175, 250));

        public SolidColorBrush ThemeColor
        {
            get { return _themeColor; }
            set
            {
                if (Equals(value, _themeColor)) return;
                _themeColor = value;
                OnPropertyChanged("ThemeColor");
            }
        }

        public SolidColorBrush ThemeAccentColor
        {
            get { return _themeAccentColor; }
            set
            {
                if (Equals(value, _themeAccentColor)) return;
                _themeAccentColor = value;
                OnPropertyChanged("ThemeAccentColor");
            }
        }

        public SolidColorBrush ThemeBackgroundColor
        {
            get { return _themeBackgroundColor; }
            set
            {
                if (Equals(value, _themeBackgroundColor)) return;
                _themeBackgroundColor = value;
                OnPropertyChanged("ThemeBackgroundColor");
            }
        }

        public SolidColorBrush ThemePageColor
        {
            get { return _themePageColor; }
            set
            {
                if (Equals(value, _themePageColor)) return;
                _themePageColor = value;
                OnPropertyChanged("ThemePageColor");
            }
        }

        private ThemeManager()
        {
            ThemeColor = new SolidColorBrush(Color.FromRgb(100, 100, 100));
            ThemeAccentColor = new SolidColorBrush(Color.FromRgb(10, 10, 10));
            ThemeBackgroundColor = new SolidColorBrush(Color.FromRgb(225, 225, 225));
            ThemePageColor = new SolidColorBrush(Color.FromRgb(31, 188, 144));
        }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}