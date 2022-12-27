using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.ViewModels.Diagram;

namespace PFConsole.Util.Diagram.Trace
{
    public class DiagramPath 
    {
        public List<DiagramVMBase> Items { get; set; }

        public DiagramPath()
        {
            Items = new List<DiagramVMBase>();
        }

    }
}
