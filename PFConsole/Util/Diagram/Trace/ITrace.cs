using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFConsole.Util.Diagram.Trace
{
    public interface ITrace
    {
        List<DiagramPath> Trace(DiagramData data);
    }
}
