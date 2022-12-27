using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.Project.Compiler.Assets;
using PFConsole.ViewModels.Diagram;
using PFModels.Data;

namespace PFConsole.Project.Compiler.Visitors
{
    class QueueMacroVisitor : IVisitor
    {

        public string Accept(Assets.IAsset asset)
        {
            QueueMacroAsset queue = asset as QueueMacroAsset;

            QM qm = (queue.Path.Items.Count == 2) ? (queue.Path.Items[1] as QMNodeVM).QMModel : null;
            var q = queue.Path.Items[0] as QueueNodeVM;

            if (q.QueueModel.Content is HFSCContent)
                return q.Gen_HFSC(qm);
            
            if (q.QueueModel.Content is CBQContent)
                return q.Gen_CBQ(qm);

            if (q.QueueModel.Content is PriQContent)
                return q.Gen_PRIQ(qm);

            return "";
        }

        
    }
}
