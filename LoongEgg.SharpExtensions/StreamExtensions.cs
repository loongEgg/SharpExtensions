using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace LoongEgg.SharpExtensions
{
    public static class StreamExtensions
    {
        public static T DeserializeToObject<T>(this Stream self) where T : new()
        {
            T ret;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(self))
            {
                ret = (T)ser.Deserialize(reader);
            }

            if (ret == null) Debugger.Break();
            return ret;
        }

        public static void SerializeToXmlFile(this Stream self, Object obj)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            XmlSerializer ser = new XmlSerializer(obj.GetType());

            using (StreamWriter writer = new StreamWriter(self))
            {
                ser.Serialize(writer, obj, ns);
            } 
        }
    }
}
