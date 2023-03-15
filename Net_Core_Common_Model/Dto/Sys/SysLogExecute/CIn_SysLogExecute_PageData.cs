namespace Net_Core_Common_Model.Dto.Sys.SysLogExecute
{
    /// <summary>
    /// 系統操作歷程-Insert欄位
    /// </summary>
    public class CIn_SysLogExecute_PageData
    {
        /// <summary>
        /// 異動作業
        /// </summary>
        public string LogExec_Module { get; set; }

        /// <summary>
        /// 執行動作
        /// </summary>
        public string LogExec_Action { get; set; }

        /// <summary>
        /// 異動項目
        /// </summary>
        public string LogExec_ChangeItem { get; set; }

        /// <summary>
        /// 異動者ID
        /// </summary>
        public string LogExec_CreateId { get; set; }

        /// <summary>
        /// 異動時間
        /// </summary>
        public DateTime LogExec_CreateDate { get; set; }

        /// <summary>
        /// 異動者IP
        /// </summary>
        public string LogExec_CreateIp { get; set; }
    }
}