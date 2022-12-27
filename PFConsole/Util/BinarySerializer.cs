using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PFConsole.Util
{
    public class BinarySerializer
    {
        public static byte[] BinarySerialize(object o)
        {
            using (var ms = new MemoryStream())
            {
                IFormatter f = new BinaryFormatter();
                f.Serialize(ms, o);
                return ms.ToArray();
            }
        }

        public static dynamic BinaryDeserialize(byte[] bytes, dynamic o)
        {
            using (var ms = new MemoryStream(bytes))
            {
                ms.Position = 0;
                IFormatter f = new BinaryFormatter();
                o = f.Deserialize(ms);
                return o;
            }
        }
    }
}