﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PFConsole.Converters
{
    public class VisibilityInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility) value == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}