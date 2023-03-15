using System.ComponentModel.DataAnnotations;

namespace Net_Core_Common_Model.Dto.Sys.SysModuleClass
{
    /// <summary>
    /// 選單分類-畫面欄位
    /// </summary>
    public class CIn_SysModuleClass_PageData
    {
        /// <summary>
        /// 上層分類(選單分類的主鍵)
        /// </summary>
        public long? ModClass_Parent { get; set; }

        /// <summary>
        /// 分類名稱
        /// </summary>
        public string ModClass_Name { get; set; }

        /// <summary>
        /// 排序(升冪)
        /// </summary>
        public decimal ModClass_order { get; set; }

        /// <summary>
        /// 狀態 (0:停用，1:啟用)
        /// </summary>
        public string ModClass_State { get; set; }
    }
}