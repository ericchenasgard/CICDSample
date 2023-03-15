namespace Net_Core_Common_Model.Dto.Sys.SysModuleClass
{
    /// <summary>
    /// 選單分類-查詢欄位
    /// </summary>
    public class CIn_SysModuleClass_Search
    {
        /// <summary>
        /// Gets or sets 主鍵
        /// </summary>
        public long? Pk_ModuleClass { get; set; }

        /// <summary>
        /// 分類名稱
        /// </summary>
        public string? ModClass_Name { get; set; }

        /// <summary>
        /// 狀態 (0:停用，1:啟用)
        /// </summary>
        public string? ModClass_State { get; set; }
    }
}