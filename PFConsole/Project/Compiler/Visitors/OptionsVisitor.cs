using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Project.Compiler.Assets;

namespace PFConsole.Project.Compiler.Visitors
{
    class OptionsVisitor : IVisitor
    {
        public string Accept(IAsset asset)
        {
            var option = asset as OptionAsset;

            return string.Format("set {0} {1}", option.Key, option.Value);
        }
    }
}
