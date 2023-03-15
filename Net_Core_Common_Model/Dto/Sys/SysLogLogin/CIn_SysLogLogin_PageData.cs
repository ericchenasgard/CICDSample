namespace Net_Core_Common_Model.Dto.Sys.SysLogLogin
{
    /// <summary>
    /// 登入Log-Insert欄位
    /// </summary>
    public class CIn_SysLogLogin_PageData
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string LogLogin_Account { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        public string LogLogin_UserAgent { get; set; }

        /// <summary>
        /// 登入訊息
        /// </summary>
        public string? LogLogin_Message { get; set; }

        /// <summary>
        /// 登入成功與否 (0:失敗，1成功)
        /// </summary>
        public bool LogLogin_Result { get; set; }

        /// <summary>
        /// IIS HOST
        /// </summary>
        public string LogLogin_IisHost { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        public DateTime LogLogin_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        public string LogLogin_CreateIp { get; set; }
    }
}