using System.ComponentModel;
using System.Reflection;

namespace Net_Core_Common_Services.Extension
{
    /// <summary>
    /// 列舉的擴充方法
    /// </summary>
    public static class ExtensionOfEnum
    {
        /// <summary>
        /// 回傳 Enum 的 Description 屬性，如果沒有 Description 屬性就回傳列舉成員的值
        /// </summary>
        /// <param name="eValue">列舉成員</param>
        /// <returns>Description 屬性或列舉成員的值</returns>
        public static string fnGetDescription(this Enum eValue)
        {
            FieldInfo fInfo = eValue.GetType().GetField(eValue.ToString());

            DescriptionAttribute dAttribute = (DescriptionAttribute)fInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            string sBack = dAttribute == null ? eValue.ToString() : dAttribute.Description;

            return sBack;
        }
    }
}
