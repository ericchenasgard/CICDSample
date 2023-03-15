using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Net_Core_Common_Model.Dto;
using Net_Core_Common_Services.Define;
using Net_Core_Common_Services.Extension;
using Net_Core_Common_Services.Public.DoNLog;

namespace Net_Core_Common_API.Method.AuthorizationMiddleware
{
    /// <summary>
    /// 複寫AuthorizationMiddlewareResultHandler
    /// </summary>
    public class DoAuthMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        /// <summary>
        /// 原生AuthorizationMiddlewareResultHandler
        /// </summary>
        private readonly AuthorizationMiddlewareResultHandler _defaultHandler = new ();

        /// <summary>
        /// 執行NLog記錄
        /// </summary>
        private readonly IDoNLog _oIDoNLog;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oIDoNLog">執行NLog記錄</param>
        public DoAuthMiddlewareResultHandler(IDoNLog oIDoNLog)
        {
            this._oIDoNLog = oIDoNLog;
        }
        #endregion

        public async Task HandleAsync(
            RequestDelegate next,
            HttpContext context,
            AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {
            // 回傳前端模糊訊息
            COut_Response cOut_Response = new COut_Response();

            try
            {
                #region 寫入NLog
                // 取得Request Header中的Authorization
                string sHeaderAuth = context.Request.Headers["authorization"].ToString();

                // 寫入NLog--Request
                this._oIDoNLog.fnDoNLogRequest(sHeaderAuth);
                #endregion

                await this._defaultHandler.HandleAsync(next, context, policy, authorizeResult);

                int iStatusCode = context.Response.StatusCode;

                if (iStatusCode != 200)
                {
                    // 回傳前端模糊訊息
                    cOut_Response.Status = iStatusCode.ToString();

                    if (iStatusCode == 401)
                    {
                        // 回傳前端模糊訊息
                        cOut_Response.Data = "";
                        cOut_Response.Message = ResponseCode.Code401.fnGetDescription();
                    }
                    else if (iStatusCode == 403)
                    {
                        // 回傳前端模糊訊息
                        cOut_Response.Data = "";
                        cOut_Response.Message = ResponseCode.Code403.fnGetDescription();
                    }
                    else if (iStatusCode != 200)
                    {
                        // 回傳前端模糊訊息
                        cOut_Response.Data = "";
                        cOut_Response.Message = ResponseCode.Code500.fnGetDescription();
                    }

                    // 寫入NLog--Response
                    this._oIDoNLog.fnDoNLogResponse(cOut_Response);

                    await context.Response.WriteAsJsonAsync(cOut_Response);
                    return;
                }
            }
            catch (Exception ex)
            {
                // 寫入NLog--Error
                this._oIDoNLog.fnDoNLogError(ex.Message);

                context.Response.StatusCode = 500;

                // 回傳前端模糊訊息
                cOut_Response.Data = "";
                cOut_Response.Message = ResponseCode.Code500.fnGetDescription();
                cOut_Response.Status = ((int)ResponseCode.Code500).ToString();

                // 寫入NLog--Response
                this._oIDoNLog.fnDoNLogResponse(cOut_Response);

                await context.Response.WriteAsJsonAsync(cOut_Response);
                return;
            }
        }
    }
}
