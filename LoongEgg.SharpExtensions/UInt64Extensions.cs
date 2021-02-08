using System;

namespace LoongEgg.SharpExtensions
{
    /// <summary>
    /// Extended methods of <see cref="UInt64"/>
    /// </summary>
    public static class UInt64Extensions
    {
        /// <summary>
        /// change the source bits[0101] to[1010]
        /// </summary>
        /// <param name="valueLength">the bits length to reverse</param>
        /// <returns>翻转后的64位无符号整形</returns>
        public static UInt64 ReverseBits(this UInt64 self, int valueLength = 64)
        {
            UInt64 ret = 0;
            for (int i = valueLength - 1; i >= 0; i--)
            {
                ret |= (self & 1) << i;
                self >>= 1;
            }
            return ret;
        }

    } 
    
}
