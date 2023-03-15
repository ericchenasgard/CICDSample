namespace Net_Core_Common_Model.Dto.Sys.SysModule
{
    /// <summary>
    /// 選單作業-查詢欄位
    /// </summary>
    public class CIn_SysModule_Search
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        public long? Pk_Module { get; set; }

        /// <summary>
        /// 作業名稱
        /// </summary>
        public string? Module_Name { get; set; }

        /// <summary>
        /// 狀態 (0:停用，1:啟用)
        /// </summary>
        public string? Module_State { get; set; }
    }
}