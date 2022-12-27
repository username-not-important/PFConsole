using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace PFConsole.Converters
{
    public class ObjectArrayToStringListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as List<string>;

            return list.Cast<object>().ToArray();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new List<string>();

            var data = (object[]) value;

            return data.Select(d => d.ToString()).ToList();
        }
    }
}