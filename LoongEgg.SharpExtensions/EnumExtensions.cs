using System;
using System.ComponentModel;
using System.Linq;

namespace LoongEgg.SharpExtensions
{
    /// <summary>
    /// Extended methods of <see cref="Enum"/>
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举类<see cref="DescriptionAttribute"/>标注的内容
        /// </summary>
        /// <param name="self"></param>
        /// <returns>标注的内容</returns>
        public static string GetDescription(this Enum self)
        {
            if (self == null)
                return string.Empty;

            System.Reflection.FieldInfo fieldInfo = self.GetType().GetField(self.ToString());
            object[] attributeArray = fieldInfo.GetCustomAttributes(inherit: false);
            string description = null;
            if (attributeArray.Any())
            {
                foreach (var attribute in attributeArray)
                {
                    description = (attribute as DescriptionAttribute)?.Description;
                    if (description != null)
                        return description;
                }
            }
            return self.ToString();
        }
    }
}
