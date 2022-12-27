using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Infragistics.Documents.Parsing;

namespace PFConsole.Util.Language
{
    public partial class PFConfLanguage
    {
        public static Color GetColor(TerminalSymbol symbol)
        {
            if (symbol.LanguageElement == LanguageElement.NewLine || symbol.LanguageElement == LanguageElement.Whitespace)
                return Colors.Black;

            if (symbol.LanguageElementName == "Comment")
                return Colors.Green;

            if (symbol.LanguageElementName == "keyword")
                return Colors.RoyalBlue;

            if (symbol.LanguageElementName == "macro")
                return Colors.BlueViolet;

            if (symbol.LanguageElementName == "StringLiteral")
                return Colors.Brown;

            return Colors.Black;
        }
    }
}
