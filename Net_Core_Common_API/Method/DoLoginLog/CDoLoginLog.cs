using Net_Core_Common_Model.Dto.Sys.SysLogLogin;
using Net_Core_Common_Repository.Sys.SysLogLogin;
using Net_Core_Common_Services.Public.GetRequestInfo;

namespace Net_Core_Common_API.Method.DoLoginLog
{
    /// <summary>
    /// 寫入登入log
    /// </summary>
    public class CDoLoginLog : IDoLoginLog
    {
        /// <summary>
        /// 使用HttpContext
        /// </summary>
        private HttpContext _httpContext { get; set; }

        /// <summary>
        /// 登入log檔(只記錄在DB裡)
        /// </summary>
        private readonly ISysLogLogin _oISysLogLogin;

        /// <summary>
        /// 取得IP
        /// </summary>
        private readonly IGetRequestInfo _oIGetRequestInfo;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="httpContextAccessor">注入IHttpContextAccessor</param>
        /// <param name="oISysLogLogin">登入log檔(只記錄在DB裡)</param>
        /// <param name="oIGetRequestInfo">取得IP</param>
        public CDoLoginLog(IHttpContextAccessor httpContextAccessor, ISysLogLogin oISysLogLogin, IGetRequestInfo oIGetRequestInfo)
        {
            this._httpContext = httpContextAccessor.HttpContext;
            this._oISysLogLogin = oISysLogLogin;
            this._oIGetRequestInfo = oIGetRequestInfo;
        }
        #endregion

        /// <summary>
        /// 寫入登入log
        /// </summary>
        /// <param name="sUserAccount">使用者帳號</param>
        /// <param name="sLoginMessage">登入訊息</param>
        /// <param name="bLoginResult">登入成功與否</param>
        /// <param name="sUserIp">建立者IP</param>
        /// <returns>成功執行的筆數</returns>
        public (int, string) fnDoLoginLog(string sUserAccount, string sLoginMessage, bool bLoginResult, string sUserIp)
        {
            CIn_SysLogLogin_PageData oCIn_SysLogLogin_PageData = new CIn_SysLogLogin_PageData
            {
                LogLogin_Account = sUserAccount,
                LogLogin_UserAgent = this._httpContext.Request.Headers["user-agent"],
                LogLogin_Message = sLoginMessage,
                LogLogin_Result = bLoginResult,
                LogLogin_IisHost = this._oIGetRequestInfo.fnGetServerIP(),
                LogLogin_CreateDate = DateTime.Now,
                LogLogin_CreateIp = sUserIp
            };

            // 取得執行結果(回傳資料/成功筆數)
            var (iChange, sMessage) = this._oISysLogLogin.fnInsert(oCIn_SysLogLogin_PageData);

            return (iChange, sMessage);
        }
    }
}
