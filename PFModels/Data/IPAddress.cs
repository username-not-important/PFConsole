using System;
using System.Xml.Serialization;

namespace PFModels.Data
{
    [XmlInclude(typeof(IPv4Address))]
    [XmlInclude(typeof(FileIPAddressList))]
    public class IPAddress : MacroContent
    {
        public override Type GetContentType()
        {
            throw new NotImplementedException();
        }

        public override string GetInlineDefinition(bool quotes)
        {
            throw new NotImplementedException();
        }
    }
}