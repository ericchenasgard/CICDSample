using System.Text.Encodings.Web;
using System.Text.Json;

namespace Net_Core_Common_Services.Public.DoJson
{
    /// <summary>
    /// Json相關動作
    /// </summary>
    public class CDoJson : IDoJson
    {
        #region Json序列化-物件
        /// <summary>
        /// Json序列化-物件
        /// </summary>
        /// <param name="oObject">要序列化的物件</param>
        /// <returns>Json字串</returns>
        public string fnDoSerializeObject(object oObject)
        {
            // 定義序列化規則
            JsonSerializerOptions jsOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string sResult = JsonSerializer.Serialize(oObject, jsOptions);

            return sResult;
        }
        #endregion
    }
}
