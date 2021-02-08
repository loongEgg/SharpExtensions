using System;
using System.Collections.Generic;

namespace LoongEgg.SharpExtensions
{
    /// <summary>
    /// Extended methods of <see cref="UInt32"/>
    /// </summary>
    public static class UInt32Extensions
    {
        /// <summary>
        /// change the source bits[0101] to[1010]
        /// </summary>
        /// <param name="valueLength">the bits length to reverse</param>
        /// <returns>翻转后的32位无符号整形</returns>
        public static UInt32 ReverseBits(this UInt32 self, int valueLength = 32)
        {
            UInt32 ret = 0;
            for (int i = valueLength - 1; i >= 0; i--)
            {
                ret |= (UInt32)((self & 1) << i);
                self >>= 1;
            }
            return ret;
        }

        /// <summary>
        /// 获取指定直接位置的flag
        /// </summary> 
        public static string GetEnumFrom(this UInt32 self, Dictionary<UInt32, string> dict)
        {
            if (dict.ContainsKey(self))
            {
                return dict[self];
            }
            return string.Empty;
        }
    }
}
