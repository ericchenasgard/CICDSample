namespace Net_Core_Common_Services.Public.DoNLog
{
    /// <summary>
    /// 執行NLog記錄
    /// </summary>
    public interface IDoNLog
    {
        /// <summary>
        /// 記錄Warning訊息
        /// </summary>
        /// <param name="sWarningMsg">要被記錄的Warning訊息</param>
        public void fnDoNLogWarning(string? sWarningMsg);

        /// <summary>
        /// 記錄Error訊息
        /// </summary>
        /// <param name="sErrorMsg">要被記錄的Error訊息</param>
        public void fnDoNLogError(string? sErrorMsg);

        /// <summary>
        /// 記錄Request
        /// </summary>
        /// <param name="cIn_Request">要被記錄的Request</param>
        public void fnDoNLogRequest(object? cIn_Request);

        /// <summary>
        /// 記錄Response
        /// </summary>
        /// <param name="cOut_Response">要被記錄的Response</param>
        public void fnDoNLogResponse(object? cOut_Response);
    }
}
