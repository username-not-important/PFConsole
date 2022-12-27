using System;
using System.Xml.Serialization;

namespace PFModels.Data
{
    [XmlInclude(typeof(Interface))]
    [XmlInclude(typeof(IPAddress))]
    [XmlInclude(typeof(HostName))]
    [XmlInclude(typeof(NegatedMacroContent))]
    [XmlInclude(typeof(PFList))]
    [XmlInclude(typeof(Macro))]
    [XmlInclude(typeof(PortValue))]
    public abstract class MacroContent
    {
        public abstract Type GetContentType();

        public abstract string GetInlineDefinition(bool quotes);
    }
}