using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Project.Compiler.Assets;

namespace PFConsole.Project.Compiler.Visitors
{
    class MacroAssignmentVisitor : IVisitor
    {

        public string Accept(Assets.IAsset asset)
        {
            var macro = (asset as MacroAssignmentAsset);

            return string.Format("{0} = {1}", macro.MacroAssignment, macro.Value);
        }
    }
}
