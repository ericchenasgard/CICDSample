using System.ComponentModel.DataAnnotations;

namespace Net_Core_Common_Model.Dto.Sys.SysModuleClass
{
    /// <summary>
    /// 選單分類-更新欄位
    /// </summary>
    public class CIn_SysModuleClass_Update : CIn_SysModuleClass_PageData
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        public long Pk_ModuleClass { get; set; }
    }
}