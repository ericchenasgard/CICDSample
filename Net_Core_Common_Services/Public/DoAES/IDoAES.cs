namespace Net_Core_Common_Services.Public.DoAES
{
    /// <summary>
    /// AES加/解密
    /// </summary>
    public interface IDoAES
    {
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="sText">記錄內文</param>
        /// <returns>加密結果/錯誤訊息</returns>
        public (string, string) fnDoAESEncrypts(string sText);

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="sText">記錄內文</param>
        /// <returns>解密結果/錯誤訊息</returns>
        public (string, string) fnDoAESDecrypts(string sText);
    }
}
