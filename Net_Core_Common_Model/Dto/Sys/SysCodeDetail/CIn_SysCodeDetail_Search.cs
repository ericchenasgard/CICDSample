namespace Net_Core_Common_Model.Dto.Sys.SysCodeDetail
{
    /// <summary>
    /// 系統代碼檔(代碼明細)-查詢欄位
    /// </summary>
    public class CIn_SysCodeDetail_Search
    {
        /// <summary>
        /// 類別代號
        /// </summary>
        public string? Cfk_CodeMain_Code { get; set; }

        /// <summary>
        /// 代碼代號
        /// </summary>
        public string? Ck_CodeDet_Code { get; set; }

        /// <summary>
        /// 代碼名稱
        /// </summary>
        public string? CodeDet_Name { get; set; }

        /// <summary>
        /// 狀態 (「0:停用，1:啟用」)
        /// </summary>
        public string? CodeDet_State { get; set; }
    }
}