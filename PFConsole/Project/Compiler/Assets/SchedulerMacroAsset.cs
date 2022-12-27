using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Util.Diagram.Trace;

namespace PFConsole.Project.Compiler.Assets
{
    class SchedulerMacroAsset : IAsset
    {
        public DiagramPath Path { get; private set; }

        public SchedulerMacroAsset(DiagramPath path)
        {
            Path = path;
        }
    }
}
