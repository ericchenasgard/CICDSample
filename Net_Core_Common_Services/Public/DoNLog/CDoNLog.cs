using Microsoft.Extensions.Logging;
using Net_Core_Common_Services.Public.DoJson;

namespace Net_Core_Common_Services.Public.DoNLog
{
    /// <summary>
    /// 執行NLog記錄
    /// </summary>
    public class CDoNLog : IDoNLog
    {
        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger<CDoNLog> _oILogger;

        /// <summary>
        /// Json序列化-物件
        /// </summary>
        private readonly IDoJson _oIDoJson;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oILogger">Logger</param>
        /// <param name="oIDoJson">Json序列化-物件</param>
        public CDoNLog(ILogger<CDoNLog> oILogger, IDoJson oIDoJson)
        {
            this._oILogger = oILogger;
            this._oIDoJson = oIDoJson;
        }
        #endregion

        #region 記錄Warning訊息
        /// <summary>
        /// 記錄Warning訊息
        /// </summary>
        /// <param name="sWarningMsg">要被記錄的Warning訊息</param>
        public void fnDoNLogWarning(string? sWarningMsg)
        {
            // 寫入NLog
            this._oILogger.LogWarning("WarningMsg：" + sWarningMsg);
        }
        #endregion

        #region 記錄Error訊息
        /// <summary>
        /// 記錄Error訊息
        /// </summary>
        /// <param name="sErrorMsg">要被記錄的Error訊息</param>
        public void fnDoNLogError(string? sErrorMsg)
        {
            // 寫入NLog
            this._oILogger.LogError("ErrorMsg：" + sErrorMsg);
        }
        #endregion

        #region 記錄Request
        /// <summary>
        /// 記錄Request
        /// </summary>
        /// <param name="cIn_Request">要被記錄的Request</param>
        public void fnDoNLogRequest(object? cIn_Request)
        {
            string sRequest = this._oIDoJson.fnDoSerializeObject(cIn_Request);

            if (!string.IsNullOrEmpty(sRequest))
            {
                // 寫入NLog
                this._oILogger.LogWarning("Request：" + sRequest);
            }
            else
            {
                this._oILogger.LogWarning("Request is Null or Empty.");
            }
        }
        #endregion

        #region 記錄Response
        /// <summary>
        /// 記錄Response
        /// </summary>
        /// <param name="cOut_Response">要被記錄的Response</param>
        public void fnDoNLogResponse(object? cOut_Response)
        {
            string sResponse = this._oIDoJson.fnDoSerializeObject(cOut_Response);

            if (!string.IsNullOrEmpty(sResponse))
            {
                // 寫入NLog
                this._oILogger.LogWarning("Response：" + sResponse);
            }
            else
            {
                this._oILogger.LogWarning("Response is Null or Empty.");
            }
        }
        #endregion
    }
}
