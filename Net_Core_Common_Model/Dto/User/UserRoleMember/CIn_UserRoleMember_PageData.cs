namespace Net_Core_Common_Model.Dto.User.UserRoleMember
{
    /// <summary>
    /// 使用者角色成員-畫面欄位
    /// </summary>
    public class CIn_UserRoleMember_PageData
    {
        /// <summary>
        /// 使用者角色主鍵
        /// </summary>
        public long Cfk_Role { get; set; }

        /// <summary>
        /// 使用者主鍵
        /// </summary>
        public long Cfk_Info { get; set; }
    }
}