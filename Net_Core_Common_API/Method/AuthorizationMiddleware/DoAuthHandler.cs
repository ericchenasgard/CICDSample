using Microsoft.AspNetCore.Authorization;
using Net_Core_Common_API.Method.AuthPermission;
using Net_Core_Common_API.Method.DoAuth;
using Net_Core_Common_Services.Public.DoNLog;

namespace Net_Core_Common_API.Method.DoAuthHandler
{
    /// <summary>
    /// 複寫AuthorizationRequirement
    /// </summary>
    public class DoAuthHandler : AuthorizationHandler<DoAuthRequirement>
    {
        /// <summary>
        /// 判斷該帳號/角色是否有呼叫API的權限
        /// </summary>
        private readonly IDoAuthProvider _oIDoAuthProvider;

        /// <summary>
        /// 執行NLog記錄
        /// </summary>
        private readonly IDoNLog _oIDoNLog;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oIDoAuthProvider">判斷該帳號/角色是否有呼叫API的權限</param>
        /// <param name="oIDoNLog">執行NLog記錄</param>
        public DoAuthHandler(IDoAuthProvider oIDoAuthProvider, IDoNLog oIDoNLog)
        {
            this._oIDoAuthProvider = oIDoAuthProvider;
            this._oIDoNLog = oIDoNLog;
        }
        #endregion

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            DoAuthRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated == false)
            {
                // 寫入NLog--Warning
                this._oIDoNLog.fnDoNLogWarning("目前請求沒有通過驗證。");

                context.Fail(new AuthorizationFailureReason(this, $"目前請求沒有通過驗證。"));
                return;
            }

            string sAccount = "";
            string sRole = "";

            var lClaims = context.User.Claims.ToList();

            if (lClaims != null)
            {
                foreach (var vClaims in lClaims)
                {
                    // 取得 Claims類型
                    string sType = vClaims.Type.ToString();

                    // 取得 Claims值
                    string sValue = vClaims.Value.ToString();

                    if (sType == "Account")
                    {
                        sAccount = sValue;
                    }

                    if (sType == "Role")
                    {
                        sRole = sValue;
                    }
                }

                var (bIsAuth, sMessage) = this._oIDoAuthProvider.fnDoAuth(sAccount, sRole);

                if (!bIsAuth || sMessage != "")
                {
                    // 寫入NLog--Warning
                    this._oIDoNLog.fnDoNLogWarning($"用戶 '{sAccount}' 授權沒有通過。");

                    context.Fail(new AuthorizationFailureReason(this, $"用戶 '{sAccount}' 授權沒有通過。"));
                }
            }
            else
            {
                // 寫入NLog--Warning
                this._oIDoNLog.fnDoNLogWarning($"用戶 '{sAccount}' 授權沒有通過。");

                context.Fail(new AuthorizationFailureReason(this, $"用戶 '{sAccount}' 授權沒有通過。"));
            }

            // 若沒有失敗，則回傳成功
            if (context.HasFailed == false)
            {
                context.Succeed(requirement);
            }
        }
    }
}
