using System;
using System.Linq;
using System.Xml.Serialization;

namespace PFModels.Data
{
    public class IPv4Address : IPAddress
    {
        public byte[] IPParts { get; set; }
        public int Subnet { get; set; }

        [XmlIgnore]
        public string Text
        {
            get
            {
                if (Subnet == -1)
                    return string.Format("{0}.{1}.{2}.{3}", IPParts[0], IPParts[1], IPParts[2], IPParts[3]);

                return string.Format("{0}.{1}.{2}.{3}/{4}", IPParts[0], IPParts[1], IPParts[2], IPParts[3], Subnet);
            }
            set
            {
                try
                {
                    var split = value.Split('.');
                    if (split[3].Contains('/'))
                    {
                        Subnet = Int32.Parse(split[3].Split('/')[1]);
                        split[3] = split[3].Split('/')[0];
                    }

                    for (int i = 0; i < 4; i++)
                        IPParts[i] = byte.Parse(split[i]);
                }
                catch (Exception)
                {}
            }
        }

        public IPv4Address()
        {
            IPParts = new byte[4];
            Subnet = -1;
        }

        public override Type GetContentType()
        {
            return typeof(IPv4Address);
        }

        public override string GetInlineDefinition(bool quotes)
        {
            return Text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}