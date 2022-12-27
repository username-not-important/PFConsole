using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using PFConsole.ViewModels.Diagram;
using PFModels;
using PFModels.Data;

namespace PFConsole.Project.Compiler
{
    static class RuleGeneratorEx
    {
        public static string Gen_Action(this ActionNodeVM vm)
        {
            return (vm.Action == PassAction.Pass ? "pass" : "block" + (vm.BlockType != BlockAction.Default ? " " + vm.BlockType.GetDescription<BlockAction>() : ""));
        }

        public static string Gen_Quick(this ActionNodeVM vm)
        {
            return (vm.IsQuick ? "quick" : "");
        }
        
        public static string Gen_IfSpec(this InterfaceSelectorVM vm, bool requireOn)
        {
            return (requireOn? "on " : "") + vm.Text;
        }

        public static string Gen_Af(this FilterNodeVM vm)
        {
            return (vm.AddressFamily != AddressFamily.None ? vm.AddressFamily.GetDescription<AddressFamily>() : "");
        }

        public static string Gen_ProtoSpec(this FilterNodeVM vm)
        {
            return (vm.Protocol != Proto.None ? " proto " + vm.Protocol.GetDescription<Proto>() : "");
        }

        public static string Gen_Host(this FilterNodeVM vm)
        {
            if (! (vm.ShouldSerializeDestinationAddress() || vm.ShouldSerializeDestinationPort() || vm.ShouldSerializeSourceAddress() || vm.ShouldSerializeSourcePort()))
                return "all";

            string Sa = gen_List(vm.SourceAddress);
            string Sp = gen_List(vm.SourcePort);
            string f = (Sa == "" && Sp == "") ? "any" : Sa + (Sp == "" ? "" : "port " + Sp);

            string Da = gen_List(vm.DestinationAddress);
            string Dp = gen_List(vm.DestinationPort);
            string t = (Da == "" && Dp == "") ? "any" : Da + (Dp == "" ? "" : "port " + Dp);

            return "from " + f + " to " + t;
        }

        private static string gen_List(ObservableCollection<MacroContent> coll)
        {
            if (coll.Count == 0)
                return "";

            if (coll.Count == 1) return coll[0].GetInlineDefinition(false);

            return (new PFList() {Items = coll}).GetInlineDefinition(false);
        }

        public static string Gen_State(this STONodeVM vm)
        {
            return (vm.ExtractOptions.ExtractAsMacro ? vm.ExtractOptions.Text : vm.GetInlineDefinition());
        }

        public static string Gen_Bandwidth(this QueueNodeVM vm)
        {
            var q = vm.QueueModel.Content;
            if (q is HFSCContent && !(q as HFSCContent).Bandwidth.IsUntouched)
                return "bandwidth " + (q as HFSCContent).Bandwidth;
            
            if (q is CBQContent && !(q as CBQContent).Bandwidth.IsUntouched)
                return "bandwidth " + (q as CBQContent).Bandwidth;

            return "";
        }

        public static string Gen_Bandwidth(this SchedulerNodeVM vm)
        {
            return "bandwidth " + (vm).SchedulerModel.TotalBandwidth;

        }

        public static string Gen_HFSC(this QueueNodeVM q, QM qm = null)
        {
            var m = q.QueueModel.Content as HFSCContent;

            string s = "queue " + q.QueueName + " " + q.Gen_Bandwidth() +
                   (m.Length == 50 ? "" : " qlimit " + m.Length) +
                   (m.Priority == 1 ? "" : " priority " + m.Priority) +

                   ((! m.UpperLimit.IsEnabled && ! m.RealTime.IsEnabled && ! m.LinkShare.IsEnabled && qm == null) ? " hfsc" :
                       (" hfsc " + gen_HFSC_opts(m.UpperLimit, m.RealTime, m.LinkShare, qm)));

            return s.Replace("  ", " ");
        }

        public static string Gen_PRIQ(this QueueNodeVM q, QM qm = null)
        {
            var m = q.QueueModel.Content as PriQContent;

            string s = "queue " + q.QueueName + " " +
                       (m.Length == 50 ? "" : " qlimit " + m.Length) +
                       (m.Priority == 1 ? "" : " priority " + m.Priority) +

                       (qm == null ? " priq " : " priq (" + gen_qm(qm) + ")");

            return s.Replace("  ", " ");
        }

        public static string Gen_CBQ(this QueueNodeVM q, QM qm = null)
        {
            var m = q.QueueModel.Content as CBQContent;

            string s = "queue " + q.QueueName + " " + q.Gen_Bandwidth() +
                       (m.Length == 50 ? "" : " qlimit " + m.Length) +
                       (m.Priority == 1 ? "" : " priority " + m.Priority) +

                       (qm == null && !m.Borrow ? " cbq " : " cbq (" + gen_qm(qm) + (m.Borrow ? " borrow " : "") + ")");

            return s.Replace("  ", " ");
        }

        private static string gen_HFSC_opts(TrippleData upperlimit, TrippleData realtime, TrippleData linkshare, QM qm = null)
        {
            string s = "(";

            s += upperlimit.IsEnabled ? "upperlimit " + upperlimit : "";
            s += " ";
            s += realtime.IsEnabled ? "realtime " + realtime : "";
            s += " ";
            s += linkshare.IsEnabled ? "linkshare " + linkshare : "";

            s += gen_qm(qm);

            s += ")";

            return s.Replace("  ", " ");
        }

        private static string gen_qm(QM qm = null)
        {
            string s = "";

            if (qm != null)
                s += (qm.ECN ? " ecn " : "") + " " + qm.Mode.GetDescription<QMMode>();

            return s.Replace("  ", " ");
        }
    }
}
