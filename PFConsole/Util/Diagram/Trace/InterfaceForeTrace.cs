using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFConsole.ViewModels.Diagram;

namespace PFConsole.Util.Diagram.Trace
{
    public class InterfaceForetrace : ITrace
    {
        private DiagramData _data;
        
        public List<DiagramPath> Trace(DiagramData data)
        {
            _data = data;

            var list = new List<DiagramPath>();

            foreach (var source in data.ItemDatas.Where(n => n.Content is InterfaceSelectorVM))
            {
                list.AddRange(rec_Trace(source));
            }

            return list;
        }

        private List<DiagramPath> rec_Trace(DiagramNodeData source)
        {
            var list = new List<DiagramPath>();
            var oug = getOutgoings(source);

            //end conditions
            if (oug.Count == 0 || (oug.Count == 1 && oug[0].Content is InterfaceSelectorVM))
            {
                list.Add(new DiagramPath() { Items = new List<DiagramVMBase> { source.Content } });
                return list;
            }

            if (source.Content is ActionNodeVM && oug.Count(d => !(d.Content is LogNodeVM)) == 0)
            {
                list.Add(new DiagramPath() { Items = new List<DiagramVMBase>((getIncommings(source).Select(d => d.Content).Where(o => o is STONodeVM)) // STO
                                                                        .Concat(oug.Select(d => d.Content)) // Log
                                                                        .Concat(new []{source.Content}).ToList())}); // Itself });
                return list;
            }

            //rec
            foreach (var data in oug.Where(d => !(d.Content is LogNodeVM || d.Content is STONodeVM)))
            {
                var paths = rec_Trace(data);
                foreach (var path in paths)
                {
                    if (source.Content is ActionNodeVM)
                    {
                        path.Items.AddRange(getIncommings(source).Select(d => d.Content).Where(d => d is STONodeVM));
                        path.Items.AddRange(oug.Select(d => d.Content).Where(d => d is LogNodeVM));
                    }
                    path.Items.Insert(0, source.Content);
                }

                list.AddRange(paths);
            }

            return list;
        }

        private List<DiagramNodeData> getIncommings(DiagramNodeData n)
        {
            return _data.ConnDatas.Where(c => c.End == _data.ItemDatas.IndexOf(n)).Select(c => _data.ItemDatas[c.Start]).ToList();
        }

        private List<DiagramNodeData> getOutgoings(DiagramNodeData n)
        {
            return _data.ConnDatas.Where(c => c.Start == _data.ItemDatas.IndexOf(n)).Select(c => _data.ItemDatas[c.End]).ToList();
        } 
    }
}
