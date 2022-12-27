using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Project.Compiler.Assets;

namespace PFConsole.Project.Compiler.Visitors
{
    class TableVisitor : IVisitor
    {

        public string Accept(Assets.IAsset asset)
        {
            var table = asset as TableAsset;
            return "table " + table.Assignment + " " + (table.Attribute != "" ? (table.Attribute + " ") : "") + table.Value;
        }
    }
}
