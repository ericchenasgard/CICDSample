namespace Net_Core_Common_Model.Dto.Sys.SysModule
{
    /// <summary>
    /// 選單作業-畫面欄位
    /// </summary>
    public class CIn_SysModule_PageData
    {
        /// <summary>
        /// 選單分類主鍵
        /// </summary>
        public long FK_ModuleClass { get; set; }

        /// <summary>
        /// 作業名稱
        /// </summary>
        public string Module_Name { get; set; }

        /// <summary>
        /// 作業路徑
        /// </summary>
        public string Module_Route { get; set; }

        /// <summary>
        /// 作業識別碼
        /// </summary>
        public string Module_Discern { get; set; }

        /// <summary>
        /// 作業外部連結
        /// </summary>
        public string? Module_outLink { get; set; }

        /// <summary>
        /// 有效日期起
        /// </summary>
        public DateTime Module_StartDate { get; set; }

        /// <summary>
        /// 有效日期迄
        /// </summary>
        public DateTime Module_EndDate { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public decimal Module_order { get; set; }

        /// <summary>
        /// 狀態 (0:停用，1:啟用)
        /// </summary>
        public string Module_State { get; set; }
    }
}