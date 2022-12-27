using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using PFModels.Data;

namespace PFConsole.Converters
{
    public class MacrosListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<MacroContent> macros = value as ObservableCollection<MacroContent>;

            if (macros.Count == 0)
                return "";

            string str = "";
            foreach (var content in macros)
                str += getText(content) + ", ";

            return str.Substring(0, str.Length - 2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string getText(MacroContent content)
        {
            if (content is Macro)
                return "$" + (content as Macro).Name;

            if (content is NegatedMacroContent)
                return "! " + getText((content as NegatedMacroContent).Content);

            return content.ToString();
        }
    }
}