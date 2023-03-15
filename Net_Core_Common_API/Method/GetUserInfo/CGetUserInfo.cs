using Net_Core_Common_Model.Dto;
using Net_Core_Common_Services.Public.GetRequestInfo;
using System.IdentityModel.Tokens.Jwt;

namespace Net_Core_Common_API.Method.GetUserInfo
{
    /// <summary>
    /// 取得使用者資訊
    /// </summary>
    public class CGetUserInfo : IGetUserInfo
    {
        /// <summary>
        /// 使用HttpContext
        /// </summary>
        private HttpContext _httpContext { get; set; }

        /// <summary>
        /// 取得IP
        /// </summary>
        private readonly IGetRequestInfo _oIGetRequestInfo;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="httpContextAccessor">注入IHttpContextAccessor</param>
        /// <param name="oIGetRequestInfo">取得IPr</param>
        public CGetUserInfo(IHttpContextAccessor httpContextAccessor, IGetRequestInfo oIGetRequestInfo)
        {
            this._httpContext = httpContextAccessor.HttpContext;
            this._oIGetRequestInfo = oIGetRequestInfo;
        }
        #endregion

        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <returns>使用者資訊</returns>
        public COut_UserInfo fnGetUserInfo()
        {
            // 取得Request Header中的Authorization
            string sHeaderAuth = this._httpContext.Request.Headers["authorization"];

            // 移除"Bearer "(含有一個字元的空白)
            sHeaderAuth = sHeaderAuth.Replace("Bearer ", "");

            // 將取到的Authorization轉成String
            var vToken = new JwtSecurityTokenHandler().ReadJwtToken(sHeaderAuth) as JwtSecurityToken;

            // 取出使用者資訊
            COut_UserInfo oCOut_UserInfo = new COut_UserInfo
            {
                sCreateId = vToken.Claims.First(x => x.Type == "name").Value,
                dCreateDate = DateTime.Now,
                sCreateIp = this._oIGetRequestInfo.fnGetClientIP()
            };

            return oCOut_UserInfo;
        }
    }
}
