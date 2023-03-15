namespace Net_Core_Common_Services.Public.GetRequestInfo
{
    /// <summary>
    /// 取得Request資訊
    /// </summary>
    public interface IGetRequestInfo
    {
        /// <summary>
        /// 取得Client端IP
        /// </summary>
        /// <returns>Client端IP</returns>
        public string fnGetClientIP();

        /// <summary>
        /// 取得Server端IP
        /// </summary>
        /// <returns>Server端IP</returns>
        public string fnGetServerIP();

        /// <summary>
        /// 取得Header的Content-Type
        /// </summary>
        /// <returns>Content-Type字串</returns>
        public string fnGetContentType();

        /// <summary>
        /// 取得Header的Method
        /// </summary>
        /// <returns>Method字串</returns>
        public string fnGetMethod();
    }
}
