using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Infragistics.Controls.Charts;
using PFConsole.Util;
using PFConsole.Util.Diagram;
using PFConsole.Util.Diagram.Trace;
using PFConsole.ViewModels.Diagram;
using PFModels.Data;

namespace PFConsole.Project.Compiler.Assets
{
    class AssetFactory
    {
        public List<IAsset> CreateAssets(PFProject project)
        {
            var result = new List<IAsset>() { new CommentAsset(getComments("Header")) };

            result.AddRange(getMacros(project));

            result.AddRange(getSTOMacros(project));
            result.AddRange(getQueueMacros(project));
            
            result.AddRange(getTables(project));

            result.AddRange(getOptions(project));


            result.AddRange(getDiagrams(project));

            return result;
        }


        public IEnumerable<IAsset> getMacros(PFProject project)
        {
            List<IAsset> list = new List<IAsset>() { new CommentAsset(getComments("Interfaces")) };

            foreach (var macro in project.Macros.Macros.Where(m => m.GetContentType() == typeof(Interface)))
                list.Add(new MacroAssignmentAsset(macro));

            list.Add(new CommentAsset("\r\n"));

            foreach (var macro in project.Macros.Macros.Where(m => m.GetContentType() != typeof(Interface)))
                list.Add(new MacroAssignmentAsset(macro));

            return list;
        }

        private IEnumerable<IAsset> getOptions(PFProject project)
        {
            List<IAsset> list = new List<IAsset>() { new CommentAsset(getComments("Options")) };

            list.AddRange(project.Options.ModifiedOptions.Select(option => new OptionAsset(option)));

            return list;
        }

        private IEnumerable<IAsset> getTables(PFProject project)
        {
            List<IAsset> list = new List<IAsset>() {new CommentAsset(getComments("Tables"))};

            list.AddRange(project.Tables.Tables.Select(table => new TableAsset(table)));

            return list;
        }

        private IEnumerable<IAsset> getDiagrams(PFProject project)
        {
            List<IAsset> list = new List<IAsset>() { new CommentAsset(getComments("Filtering")) };

            InterfaceBacktrace IfB_trc = new InterfaceBacktrace();
            InterfaceForetrace IfF_trc = new InterfaceForetrace();

            foreach (var diagramInfo in project.Diagrams.Diagrams)
            {
                list.Add(new CommentAsset("### Diagram: " + diagramInfo.Name));

                var pathsI = IfB_trc.Trace(TextSerializer.XmlDeserializeFromString<DiagramData>(diagramInfo.Data));
                var pathsO = IfF_trc.Trace(TextSerializer.XmlDeserializeFromString<DiagramData>(diagramInfo.Data));

                list.AddRange(pathsI.Select(p => new FilteringAsset(p)));
                list.AddRange(pathsO.Select(p => new FilteringAsset(p)));
            }

            return list;
        }

        private IEnumerable<IAsset> getSTOMacros(PFProject project)
        {
            List<IAsset> list = new List<IAsset>() { new CommentAsset(getComments("STO")) };

            foreach (var diagramInfo in project.Diagrams.Diagrams)
            {
                DiagramData datas = TextSerializer.XmlDeserializeFromString<DiagramData>(diagramInfo.Data);
                foreach (var nodeData in datas.ItemDatas)
                {
                    var stoNode = nodeData.Content as STONodeVM;
                    if (stoNode == null)
                        continue;

                    if (stoNode.ExtractOptions.ExtractAsMacro)
                        list.Add(new MacroAssignmentAsset(stoNode.ExtractOptions.ExtractName, stoNode.GetInlineDefinition()));
                }
            }

            return list;
        }

        private IEnumerable<IAsset> getQueueMacros(PFProject project)
        {
            List<IAsset> list = new List<IAsset>() { new CommentAsset(getComments("Queues")) };

            QueueTrace t = new QueueTrace();
            foreach (var diagramInfo in project.Diagrams.Diagrams)
            {
                DiagramData datas = TextSerializer.XmlDeserializeFromString<DiagramData>(diagramInfo.Data);
                
                var qPaths = t.Trace(datas);

                list.AddRange(qPaths.Select(q => new QueueMacroAsset(q)));
            }

            SchedulerTrace t2 = new SchedulerTrace();
            foreach (var diagramInfo in project.Diagrams.Diagrams)
            {
                DiagramData datas = TextSerializer.XmlDeserializeFromString<DiagramData>(diagramInfo.Data);

                var sPaths = t2.Trace(datas);

                list.AddRange(sPaths.Select(s => new SchedulerMacroAsset(s)));
            }

            return list;
        }


        private string getComments(string part)
        {
            var streamInfo = App.GetResourceStream(new Uri(string.Format("/PFConsole;component/Project/Compiler/Comments/{0}Comments.txt", part), UriKind.Relative));

            if (streamInfo != null)
                return new StreamReader(streamInfo.Stream).ReadToEnd();
            return "";
        }
    }
}
