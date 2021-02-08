using System;
using System.Collections;
using System.Collections.Generic;

namespace LoongEgg.SharpExtensions
{
    public static class byteExtensions
    {
        /// <summary>
        /// 遍历获取字典中的flag标志, 如果某位有效则该为flag为flag本身, 否则为!flag
        /// </summary>
        /// <param name="self"></param>
        /// <param name="dict"></param>
        /// <param name="isRevLogic">反逻辑标志</param>
        /// <returns>遍历获取的flag有效标记</returns>
        public static string[] GetFlagsFrom(this byte[] self, Dictionary<UInt32, string> dict, bool isRevLogic = false)
        {
            var bits = new BitArray(self);

            var res = new List<string>();

            if (isRevLogic)
            {
                foreach (var key in dict.Keys)
                {
                    if (!bits.HasFlagAt(key))
                        res.Add(dict[key]);
                    else
                        res.Add($"!{dict[key]}");
                }
            }
            else
            {
                foreach (var key in dict.Keys)
                {
                    if (bits.HasFlagAt(key))
                        res.Add(dict[key]);
                    else
                        res.Add($"!{dict[key]}");
                }
            }
            return res.ToArray();
        }
        public static string ToHexString(this byte[] self, char spliter = '_') 
            => BitConverter.ToString(self).Replace('-', spliter);

        /// <summary>
        /// 0xAA -> TrueFalseTrueFalse TrueFalseTrueFalse
        /// </summary>  
        public static BitArray ToBitArray(this byte[] self)
            => new BitArray(self);

        /// <summary>
        /// {0xAA, 0x55, 0x55} -> 0101_0101_0101_0101_1010_1010
        /// </summary>  
        public static string ToBitString(this byte[] self, char spliter = '_')
            => (new BitArray(self)).ToBitString(spliter);
    }
}
