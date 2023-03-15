namespace Net_Core_Common_Model.Dto.User.UserRoleAuth
{
    /// <summary>
    /// 使用者角色作業權限-畫面欄位
    /// </summary>
    public class CIn_UserRoleAuth_PageData
    {
        /// <summary>
        /// 使用者角色主鍵
        /// </summary>
        public long Cfk_Role { get; set; }

        /// <summary>
        /// 選單作業主鍵
        /// </summary>
        public long Cfk_Module { get; set; }
    }
}