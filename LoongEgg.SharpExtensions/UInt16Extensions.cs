using System;

namespace LoongEgg.SharpExtensions
{
    /// <summary>
    /// Extended methods of <see cref="UInt16"/>
    /// </summary>
    public static class UInt16Extensions
    {
        /// <summary>
        /// change the source bits[0101] to[1010]
        /// </summary>
        /// <param name="valueLength">the bits length to reverse</param>
        /// <returns>翻转后的16位无符号整形</returns>
        public static UInt16 ReverseBits(this UInt16 self, int valueLength = 16)
        {
            UInt16 ret = 0;
            for (int i = valueLength - 1; i >= 0; i--)
            {
                ret |= (UInt16)((self & 1) << i);
                self >>= 1;
            }
            return ret;
        }

    }
}
