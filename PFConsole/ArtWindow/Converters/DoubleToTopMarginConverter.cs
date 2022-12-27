using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PFConsole.ArtWindow.Converters
{
    public class DoubleToTopMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double d = (double) value;

            return new Thickness(0, d, 0, -1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}