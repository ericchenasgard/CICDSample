namespace Net_Core_Common_Model.Dto.Sys.SysParameter
{
    /// <summary>
    /// 系統參數檔-查詢欄位
    /// </summary>
    public class CIn_SysParameter_Search
    {
        /// <summary>
        /// 參數群組
        /// </summary>
        public string? Ck_Par_Group { get; set; }

        /// <summary>
        /// 參數編號
        /// </summary>
        public string? Ck_Par_Code { get; set; }

        /// <summary>
        /// 參數名稱
        /// </summary>
        public string? Par_Name { get; set; }

        /// <summary>
        /// 狀態 (0:停用，1:啟用)
        /// </summary>
        public string? Par_State { get; set; }
    }
}