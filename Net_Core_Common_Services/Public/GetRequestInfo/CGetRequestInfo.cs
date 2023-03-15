using Microsoft.AspNetCore.Http;

namespace Net_Core_Common_Services.Public.GetRequestInfo
{
    /// <summary>
    /// 取得Request資訊
    /// </summary>
    public class CGetRequestInfo : IGetRequestInfo
    {
        /// <summary>
        /// 使用HttpContext取得Request資訊
        /// </summary>
        private HttpContext _httpContext { get; set; }

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="httpContextAccessor">注入IHttpContextAccessor</param>
        public CGetRequestInfo(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContext = httpContextAccessor.HttpContext;
        }
        #endregion

        #region 取得Client端IP
        /// <summary>
        /// 取得Client端IP
        /// </summary>
        /// <returns>Client端IP</returns>
        public string fnGetClientIP()
        {
            string sCIP = this._httpContext.Connection.RemoteIpAddress.ToString();
            return sCIP;
        }
        #endregion

        #region 取得Server端IP
        /// <summary>
        /// 取得Server端IP
        /// </summary>
        /// <returns>Server端IP</returns>
        public string fnGetServerIP()
        {
            string sSIP = this._httpContext.Connection.LocalIpAddress.ToString();
            return sSIP;
        }
        #endregion

        #region 取得Header的Content-Type
        /// <summary>
        /// 取得Header的Content-Type
        /// </summary>
        /// <returns>Content-Type字串</returns>
        public string fnGetContentType()
        {
            string sContentType = this._httpContext.Request.ContentType.ToString();
            return sContentType;
        }
        #endregion

        #region 取得Header的Method
        /// <summary>
        /// 取得Header的Method
        /// </summary>
        /// <returns>Method字串</returns>
        public string fnGetMethod()
        {
            string sMethod = this._httpContext.Request.Method.ToString();
            return sMethod;
        }
        #endregion
    }
}
