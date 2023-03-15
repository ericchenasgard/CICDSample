namespace Net_Core_Common_Model.Dto.Sys.SysModuleControl
{
    /// <summary>
    /// 選單作業控制項-查詢欄位
    /// </summary>
    public class CIn_SysModuleControl_Search
    {
        /// <summary>
        /// 選單作業主鍵
        /// </summary>
        public long? Cfk_Module { get; set; }

        /// <summary>
        /// 選單作業控制項-識別碼
        /// </summary>
        public string? ModCon_Code { get; set; }

        /// <summary>
        /// 選單作業控制項-名稱
        /// </summary>
        public string? ModCon_Name { get; set; }
    }
}