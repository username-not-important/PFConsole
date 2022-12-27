using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Util.Diagram.Trace;

namespace PFConsole.Project.Compiler.Assets
{
    class QueueMacroAsset : IAsset
    {
        public DiagramPath Path { get; private set; }

        public QueueMacroAsset(DiagramPath path)
        {
            Path = path;
        }
    }
}
