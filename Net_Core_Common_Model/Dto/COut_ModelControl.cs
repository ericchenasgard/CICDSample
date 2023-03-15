using Net_Core_Common_Model.Dto.Sys.SysModuleControl;

namespace Net_Core_Common_Model.Dto
{
    /// <summary>
    /// 選單權限控制樹(資料回傳的格式)
    /// </summary>
    public class COut_ModelControl
    {
        /// <summary>
        /// 選單分類/作業的PK
        /// </summary>
        public string Module_Pk { get; set; }

        /// <summary>
        /// 選單分類/作業的名稱
        /// </summary>
        public string Module_Name { get; set; }

        /// <summary>
        /// 選單分類/作業的父選單PK
        /// </summary>
        public string? Module_Parent { get; set; }

        /// <summary>
        /// 選單分類/作業的排序
        /// </summary>
        public string Module_order { get; set; }

        /// <summary>
        /// 選單分類/作業的控制項群組
        /// </summary>
        public List<COut_SysModuleControl>? Module_Controls { get; set; }
    }
}
