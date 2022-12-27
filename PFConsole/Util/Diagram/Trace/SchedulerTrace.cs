using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.ViewModels.Diagram;

namespace PFConsole.Util.Diagram.Trace
{
    public class SchedulerTrace : ITrace
    {

        /// <summary>
        /// Contains a Scheduler (main) [and a series of Schedulers and Queues]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<DiagramPath> Trace(DiagramData data)
        {
            var list = new List<DiagramPath>();
            var sched = data.ItemDatas.Where(d => d.Content is SchedulerNodeVM).ToList();

            while (sched.Count > 0)
            {
                for (int i = 0; i < sched.Count; i++)
                {
                    var n = sched[i];

                    DiagramPath p = new DiagramPath();
                    p.Items.Add(n.Content);

                    var back = data.ConnDatas.Where(c => c.StartPoint == "Scheduler*" && c.End == data.ItemDatas.IndexOf(n));
                    if (back.Count() != null && back.FirstOrDefault(c => sched.Contains(data.ItemDatas[c.Start])) != null)
                        continue;

                    var con = data.ConnDatas.Where(c => "Scheduler*Queue*".Contains(c.StartPoint) && c.End == data.ItemDatas.IndexOf(n));
                    p.Items.AddRange(con.Select(c => data.ItemDatas[c.Start].Content));

                    sched.RemoveAt(i--);

                    list.Add(p);
                }
            }

            return list;
        }
    }
}
