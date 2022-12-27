using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.ViewModels.Diagram;
using PFModels.Data;

namespace PFConsole.Util.Diagram.Trace
{
    public class QueueTrace : ITrace
    {
        private DiagramData _data;

        /// <summary>
        /// Contains a Queue [and a QM after]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<DiagramPath> Trace(DiagramData data)
        {
            _data = data;

            var list = new List<DiagramPath>();
            foreach (var source in data.ItemDatas.Where(d => d.Content is QueueNodeVM))
            {
                DiagramPath p = new DiagramPath();
                p.Items.Add(source.Content);

                var con = data.ConnDatas.FirstOrDefault(c => c.StartPoint == "QM*" && c.End == data.ItemDatas.IndexOf(source));
                if (con != null)
                    p.Items.Add(data.ItemDatas[con.Start].Content);
                
                list.Add(p);
            }

            return list;
        }
    }
}
