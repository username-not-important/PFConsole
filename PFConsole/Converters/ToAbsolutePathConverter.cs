using System;
using System.Globalization;
using System.Windows.Data;

namespace PFConsole.Converters
{
    public class ToAbsolutePathConverter : IValueConverter
    {
        public string Extension { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter + value.ToString().Replace(" ", "") + (Extension != null ? "." + Extension : "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}