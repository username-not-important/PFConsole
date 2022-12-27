using System.Xml.Serialization;

namespace PFConsole.ViewModels.Diagram
{
    [XmlInclude(typeof(ActionNodeVM))]
    [XmlInclude(typeof(DEFNodeVM))]
    [XmlInclude(typeof(FilterNodeVM))]
    [XmlInclude(typeof(InterfaceSelectorVM))]
    [XmlInclude(typeof(LogNodeVM))]
    [XmlInclude(typeof(MarkNodeVM))]
    [XmlInclude(typeof(QMNodeVM))]
    [XmlInclude(typeof(QueueNodeVM))]
    [XmlInclude(typeof(ServerNodeVM))]
    [XmlInclude(typeof(SchedulerNodeVM))]
    [XmlInclude(typeof(STONodeVM))]
    public class DiagramVMBase
    {
        public virtual void FixSerializationIssues()
        {}

        public virtual string GetInlineDefinition()
        {
            return "";
        }
    }
}