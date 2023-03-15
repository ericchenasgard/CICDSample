namespace Net_Core_Common_Model.Dto.Sys.SysCodeMain
{
    /// <summary>
    /// 系統代碼檔(代碼類別)-更新欄位
    /// </summary>
    public class CIn_SysCodeMain_Update
    {
        /// <summary>
        /// 類別代號
        /// </summary>
        public string Pk_CodeMain_Code { get; set; }

        /// <summary>
        /// 類別名稱
        /// </summary>
        public string CodeMain_Name { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? CodeMain_Remark { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string CodeMain_State { get; set; }
    }
}