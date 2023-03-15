namespace Net_Core_Common_Model.Dto.Sys.SysLogError
{
    /// <summary>
    /// 錯誤Log-Insert欄位
    /// </summary>
    public class CIn_SysLogError_PageData
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        public long Pk_LogError { get; set; }

        /// <summary>
        /// Exception Type
        /// </summary>
        public string LogError_ExceptionType { get; set; }

        /// <summary>
        /// Exception Source
        /// </summary>
        public string LogError_ExceptionSource { get; set; }

        /// <summary>
        /// Exception StackTrace
        /// </summary>
        public string LogError_ExceptionStackTrace { get; set; }

        /// <summary>
        /// Exception TargetSite
        /// </summary>
        public string LogError_ExceptionTargetSite { get; set; }

        /// <summary>
        /// Exception Message
        /// </summary>
        public string LogError_ExceptionMessage { get; set; }

        /// <summary>
        /// IIS HOST
        /// </summary>
        public string LogError_IisHost { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        public string LogError_Agent { get; set; }

        /// <summary>
        /// 建立者ID (Log的建立者有可能是訪客，所以型態用String)
        /// </summary>
        public string LogError_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        public DateTime LogError_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        public string LogError_CreateIp { get; set; }
    }
}