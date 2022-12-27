using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Util.Diagram.Trace;

namespace PFConsole.Project.Compiler.Assets
{
    class FilteringAsset : IAsset
    {
        public DiagramPath Path { get; private set; }

        public FilteringAsset(DiagramPath p)
        {
            Path = p;
        }
    }
}
