using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Project.Compiler.Assets;
using PFConsole.ViewModels.Diagram;
using PFModels.Data;

namespace PFConsole.Project.Compiler.Visitors
{
    class SchedulerMacroVisitor : IVisitor
    {

        public string Accept(Assets.IAsset asset)
        {
            SchedulerMacroAsset a = asset as SchedulerMacroAsset;
            
            var s = a.Path.Items[0] as SchedulerNodeVM;

            string list = " { ";

            for (int i = 1; i < a.Path.Items.Count; i++)
            {
                var vm = a.Path.Items[i];
                if (vm is SchedulerNodeVM)
                    list += (i != 1 ? ", " : "") + (vm as SchedulerNodeVM).SchedulerName;
                else if (vm is QueueNodeVM)
                    list += (i != 1 ? ", " : "") + (vm as QueueNodeVM).QueueName;
            }

            list += " }";

            string str = "queue " + s.SchedulerName + " " + s.Gen_Bandwidth() + list;

            return str;
        }
    }
}
