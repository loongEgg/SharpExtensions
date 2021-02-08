using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LoongEgg.SharpExtensions
{
    public static class stringExtensions
    {

        /// <summary>
        /// 将xml字符串反序列化, 注意为UTF8编码
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="self">xml字符串</param>
        /// <returns>序列化后的实例</returns>
        public static T Deserialize<T>(this string self)
        {
            T ret;
            byte[] buffer = Encoding.UTF8.GetBytes(self);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(new MemoryStream(buffer)))
            {
                ret = (T)ser.Deserialize(reader);
            }

            return ret;
        }

        /// <summary>
        /// 将字符串当做xml文件路径读取为类的实例
        /// </summary>
        /// <typeparam name="T">target type of class</typeparam>
        /// <param name="path">the path of xml file</param>
        /// <returns>the instance of target type</returns>
        public static T ReadAsXmlFileToObject<T>(this string path) where T : new()
        {
            T ret;
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StreamReader reader = new StreamReader(path))
            {
                ret = (T)ser.Deserialize(reader);
            }

            return ret;
        }

        /// <summary>
        /// 将字符串当做xml文件路径, 把类的实例序列化
        /// </summary>
        /// <param name="path">the path of xml file</param>
        /// <param name="obj">the object to serialize</param>
        /// <example>
        /// <code>
        /// [XmlRoot]
        /// public class StubClass
        /// {
        ///    [XmlArray]
        ///    [XmlArrayItem("Item")]
        ///    public string[] Items { get; set; }
        ///
        ///    [XmlAttribute]
        ///    public string Label { get; set; }
        ///
        ///    [XmlAttribute]
        ///    public int Id { get; set; } 
        /// }
        /// </code>
        /// </example>
        public static void CreatAsXmlFile(this string path, Object obj)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            XmlSerializer ser = new XmlSerializer(obj.GetType());

            using (StreamWriter writer = new StreamWriter(path))
            {
                ser.Serialize(writer, obj, ns);
            }
        }

        /// <summary>
        /// 将字符串分割为UInt32和string的键值对
        /// </summary>
        /// <param name="self">带分隔的字符串, 比如"0: fla0; 1: fla1."</param>
        /// <param name="separator">分隔符, [default] = new char[] { ':', ',', ';', ' ', '.' }</param>
        /// <returns>分割好的键值对</returns>
        public static Dictionary<UInt32, string> ToUInt32StringDictonary(this string self, params char[] separator)
        {
            if (separator == null | separator.Length <= 0)
            {
                separator = new char[] { ':', ',', ';', ' ', '.' };
            }

            var strs = self.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            var ret = new Dictionary<UInt32, string>();
            UInt32 index;
            for (int i = 0; i <= strs.Length - 2; i++)
            {
                if (UInt32.TryParse(strs[i], out index))
                {
                    i += 1;
                    ret.Add(index, strs[i]);
                }
            }

            return ret;
        }

        /// <summary>
        /// <see cref="ToUInt32StringDictonary(string, char[])"/>
        /// </summary>
        /// <param name="self">带分隔的字符串, 比如"0: fla0; 1: fla1."</param>
        /// <param name="separator">分隔符, [default] = new char[] { ':', ',', ';', ' ', '.' }</param>
        /// <returns>分割好的键值对</returns>
        public static Dictionary<UInt32, string> ToFlagDictonary(this string self, params char[] separator)
            => self.ToUInt32StringDictonary(separator);

        /// <summary>
        /// <see cref="ToUInt32StringDictonary(string, char[])"/>
        /// </summary>
        /// <param name="self">带分隔的字符串, 比如"0: fla0; 1: fla1."</param>
        /// <param name="separator">分隔符, [default] = new char[] { ':', ',', ';', ' ', '.' }</param>
        /// <returns>分割好的键值对</returns>
        public static Dictionary<UInt32, string> ToEumDictonary(this string self, params char[] separator)
            => self.ToUInt32StringDictonary(separator);
    }
}
