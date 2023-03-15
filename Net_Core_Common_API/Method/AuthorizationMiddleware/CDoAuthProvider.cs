using Net_Core_Common_API.Method.DoAuth;
using Net_Core_Common_Repository.User.UserInfoControl;
using Net_Core_Common_Repository.User.UserRoleControl;

namespace Net_Core_Common_API.Method.DoAuthProvider
{
    /// <summary>
    /// 判斷該帳號/角色是否有呼叫API的權限
    /// </summary>
    public class CDoAuthProvider : IDoAuthProvider
    {
        /// <summary>
        /// 使用HttpContext
        /// </summary>
        private HttpContext _httpContext { get; set; }

        /// <summary>
        /// 使用者角色/模組代號/控制項代號
        /// </summary>
        private readonly IUserRoleControl _oIUserRoleControl;

        /// <summary>
        /// 使用者帳號/模組代號/控制項代號
        /// </summary>
        private readonly IUserInfoControl _oIUserInfoControl;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="httpContextAccessor">注入IHttpContextAccessor</param>
        /// <param name="oIUserInfoControl">使用者帳號/模組名稱/擁有的控制項</param>
        /// <param name="oIUserRoleControl">使用者角色/模組名稱/擁有的控制項</param>
        public CDoAuthProvider(IHttpContextAccessor httpContextAccessor, IUserRoleControl oIUserRoleControl, IUserInfoControl oIUserInfoControl)
        {
            this._httpContext = httpContextAccessor.HttpContext;
            this._oIUserRoleControl = oIUserRoleControl;
            this._oIUserInfoControl = oIUserInfoControl;
        }
        #endregion

        /// <summary>
        /// 判斷該帳號/角色是否有呼叫API的權限
        /// </summary>
        /// <param name="sAccount">使用者帳號</param>
        /// <param name="sRole">使用者角色</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (bool, string) fnDoAuth(string sAccount, string sRole)
        {
            // 查詢結果
            bool bResult = false;

            // 回傳訊息
            string sMessage = "";

            // 角色是否有權限
            bool bIsRole = false;

            // 帳號是否有權限
            bool bIsAccount = false;

            // 取得 Request Path(/api/{Controller}/{Action})
            string sRoute = "";

            try
            {
                #region 取得 API Controller/Action的名稱
                sRoute = this._httpContext.Request.Path.Value.ToString();
                string[] sSeparator = sRoute.Split("/", 3, StringSplitOptions.RemoveEmptyEntries);
                string sModuleNmae = sSeparator[1].ToString();
                string sControlName = sSeparator[2].ToString();
                #endregion

                #region 取得角色，並判斷該角色是否有權限
                var (bIsRoleAuth, sRoleMessage) = this._oIUserRoleControl.fnGetName(sRole, sModuleNmae, sControlName);

                if (bIsRoleAuth && sRoleMessage == "")
                {
                    bIsRole = true;
                }
                #endregion

                #region 取得帳號，並判斷該帳號是否有特殊權限
                var (bIsAccountAuth, sAccountMessage) = this._oIUserInfoControl.fnGetName(sAccount, sModuleNmae, sControlName);

                if (bIsAccountAuth && sAccountMessage == "")
                {
                    bIsAccount = true;
                }
                #endregion

                if (bIsRole || bIsAccount)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (bResult, sMessage);
        }
    }
}
