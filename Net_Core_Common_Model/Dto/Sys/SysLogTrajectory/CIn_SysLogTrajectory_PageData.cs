namespace Net_Core_Common_Model.Dto.Sys.SysLogTrajectory
{
    /// <summary>
    /// 程式執行Log-Insert欄位
    /// </summary>
    public class CIn_SysLogTrajectory_PageData
    {
        /// <summary>
        /// Route Group
        /// </summary>
        public string LogTra_Group { get; set; }

        /// <summary>
        /// Route Controller
        /// </summary>
        public string LogTra_Controller { get; set; }

        /// <summary>
        /// Route Action
        /// </summary>
        public string LogTra_Action { get; set; }

        /// <summary>
        /// Request內容
        /// </summary>
        public string LogTra_RequestContent { get; set; }

        /// <summary>
        /// Request時間
        /// </summary>
        public DateTime LogTra_RequestTime { get; set; }

        /// <summary>
        /// Response內容
        /// </summary>
        public string LogTra_ResponseContent { get; set; }

        /// <summary>
        /// Response時間
        /// </summary>
        public DateTime LogTra_ResponseTime { get; set; }

        /// <summary>
        /// IIS HOST
        /// </summary>
        public string LogTra_IisHost { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        public string LogTra_Agent { get; set; }

        /// <summary>
        /// 建立者ID(Log的建立者有可能是訪客，所以型態用String)
        /// </summary>
        public string LogTra_CreateId { get; set; }

        /// <summary>
        /// 建檔日期
        /// </summary>
        public DateTime LogTra_CreateDate { get; set; }

        /// <summary>
        /// 建立者IP
        /// </summary>
        public string LogTra_CreateIp { get; set; }
    }
}