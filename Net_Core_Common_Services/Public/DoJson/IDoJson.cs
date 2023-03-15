namespace Net_Core_Common_Services.Public.DoJson
{
    /// <summary>
    /// Json相關動作
    /// </summary>
    public interface IDoJson
    {
        /// <summary>
        /// Json序列化-物件
        /// </summary>
        /// <param name="oObject">要序列化的物件</param>
        /// <returns>Json字串</returns>
        public string fnDoSerializeObject(object oObject);
    }
}
