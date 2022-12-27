using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Project.Compiler.Assets;
using PFConsole.Util.Diagram.Trace;
using PFConsole.ViewModels.Diagram;
using PFModels;

namespace PFConsole.Project.Compiler.Visitors
{
    class FilteringVisitor : IVisitor
    {
        public string Accept(Assets.IAsset asset)
        {
            DiagramPath p = (asset as FilteringAsset).Path;

            string pattern = p.Items.Aggregate("", (current, item) => current + getToken(item));
            return resolvePattern(p, pattern).Replace("  ", " ");
        }

        private string resolvePattern(DiagramPath p, string pattern)
        {
            string _pattern = pattern.Replace("s", "").Replace("l", "");

            bool isLog = pattern.Contains("l");
            bool isState = pattern.Contains("s");

            if (_pattern == "IFA" || _pattern == "FAI")
            {
                FilterNodeVM filter = p.Items[pattern.IndexOf('F')] as FilterNodeVM;
                ActionNodeVM action = p.Items[pattern.IndexOf('A')] as ActionNodeVM;
                InterfaceSelectorVM If = p.Items[pattern.IndexOf('I')] as InterfaceSelectorVM;
                STONodeVM sto = isState ? p.Items[pattern.IndexOf('s')] as STONodeVM : null;


                return resolveFAI(filter, action , If, sto , pattern == "FAI" ? "in" : "out", isLog, isState);
            }

            if (_pattern.StartsWith("IFAU"))
            {
                FilterNodeVM filter = p.Items[pattern.IndexOf('F')] as FilterNodeVM;
                ActionNodeVM action = p.Items[pattern.IndexOf('A')] as ActionNodeVM;
                InterfaceSelectorVM If = p.Items[pattern.IndexOf('I')] as InterfaceSelectorVM;
                STONodeVM sto = isState ? p.Items[pattern.IndexOf('s')] as STONodeVM : null;
                QueueNodeVM queue = p.Items[pattern.IndexOf('U')] as QueueNodeVM;

                return resolveIFAU(filter, action, If, sto, queue, "out", isLog, isState);
            }

            if (_pattern.StartsWith("IFAC"))
            {
                FilterNodeVM filter = p.Items[pattern.IndexOf('F')] as FilterNodeVM;
                ActionNodeVM action = p.Items[pattern.IndexOf('A')] as ActionNodeVM;
                InterfaceSelectorVM If = p.Items[pattern.IndexOf('I')] as InterfaceSelectorVM;
                STONodeVM sto = isState ? p.Items[pattern.IndexOf('s')] as STONodeVM : null;
                SchedulerNodeVM sched = p.Items[pattern.IndexOf('C')] as SchedulerNodeVM;

                return resolveIFAC(filter, action, If, sto, sched, "out", isLog, isState);
            }

            //if (pattern.EndsWith("CI") && !pattern.Contains("A"))
            //{
            //    SchedulerNodeVM scheduler = p.Items[pattern.LastIndexOf('C')] as SchedulerNodeVM;
            //    InterfaceSelectorVM If = p.Items[pattern.LastIndexOf('I')] as InterfaceSelectorVM;

            //    return resolveCI(scheduler, If);
            //}

            return "";
        }

        private string resolveFAI(FilterNodeVM f, ActionNodeVM a, InterfaceSelectorVM i, STONodeVM sto, string dir, bool isLog, bool isState)
        {
            return a.Gen_Action() + " " + dir + (isLog ? " log " : "") + " " + a.Gen_Quick() + " " + i.Gen_IfSpec(true) +
                " " + f.Gen_Af() + " " + f.Gen_ProtoSpec() + " " + f.Gen_Host() + " " + (isState ? sto.Gen_State() : "");
        }

        private string resolveIFAU(FilterNodeVM f, ActionNodeVM a, InterfaceSelectorVM i, STONodeVM sto, QueueNodeVM queue, string dir, bool isLog, bool isState)
        {
            return a.Gen_Action() + " " + dir + (isLog ? " log " : "") + " " + a.Gen_Quick() + " " + i.Gen_IfSpec(true) +
                " " + f.Gen_Af() + " " + f.Gen_ProtoSpec() + " " + f.Gen_Host() + " " + (isState ? sto.Gen_State() : "") + " queue " + queue.QueueName;
        }

        private string resolveIFAC(FilterNodeVM f, ActionNodeVM a, InterfaceSelectorVM i, STONodeVM sto, SchedulerNodeVM sched, string dir, bool isLog, bool isState)
        {
            return a.Gen_Action() + " " + dir + (isLog ? " log " : "") + " " + a.Gen_Quick() + " " + i.Gen_IfSpec(true) +
                " " + f.Gen_Af() + " " + f.Gen_ProtoSpec() + " " + f.Gen_Host() + " " + (isState ? sto.Gen_State() : "") + " queue " + sched.SchedulerName;
        }

        private string resolveCI(SchedulerNodeVM s, InterfaceSelectorVM i)
        {
            return "altq on " + i.Text + " queue " + s.SchedulerName;
        }

        private string getToken(DiagramVMBase item)
        {
            if (item is ActionNodeVM) return "A";
            if (item is DEFNodeVM) return "D";
            if (item is FilterNodeVM) return "F";
            if (item is InterfaceSelectorVM) return "I";
            if (item is LogNodeVM) return "l";
            if (item is MarkNodeVM) return "M";
            if (item is QMNodeVM) return "Q";
            if (item is QueueNodeVM) return "U";
            if (item is SchedulerNodeVM) return "C";
            if (item is ServerNodeVM) return "S";
            if (item is STONodeVM) return "s";

            return "";
        }
    }
}
