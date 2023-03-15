namespace Net_Core_Common_Model.Dto.User.UserRole
{
    /// <summary>
    /// 使用者角色設定-畫面欄位
    /// </summary>
    public class CIn_UserRole_PageData
    {
        /// <summary>
        /// 角色名稱
        /// </summary>
        public string Role_Name { get; set; }

        /// <summary>
        /// 有效日期起
        /// </summary>
        public DateTime Role_StartDate { get; set; }

        /// <summary>
        /// 有效日期迄
        /// </summary>
        public DateTime Role_EndDate { get; set; }

        /// <summary>
        /// 狀態(0:停用，1:啟用)
        /// </summary>
        public string Role_State { get; set; }
    }
}