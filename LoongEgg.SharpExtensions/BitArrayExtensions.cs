using System;
using System.Collections;
using System.Text;

namespace LoongEgg.SharpExtensions
{
    public static class BitArrayExtensions
    {
        /// <summary>
        /// 判断某bit位的flag是否有效
        /// </summary> 
        public static bool HasFlagAt(this BitArray self, UInt32 index) => self[(int)index] == true;
         
        /// <summary>
        /// {false, true , false, true, false, true, false, true} / TFTF_TFTF -> 1010_1010
        /// </summary> 
        public static string ToBitString(this BitArray self, char spliter = '_')
        {
            StringBuilder sb = new StringBuilder();

            int count = 1;
            for (int i = self.Count - 1; i >= 0; i--)
            {
                sb.Append(self[i] ? "1" : "0");
                if (count % 4 == 0 && i > 2) sb.Append(spliter);
                count++;
            }

            return sb.ToString();
        }
    }
}
