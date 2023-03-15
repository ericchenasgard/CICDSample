namespace Net_Core_Common_Model.Dto.User.UserRoleMember
{
    /// <summary>
    /// 使用者角色名稱&使用者名稱
    /// </summary>
    public class COut_UserRoleInfoName
    {
        /// <summary>
        /// 使用者角色主鍵
        /// </summary>
        public long Cfk_Role { get; set; }

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
        /// 使用者主鍵
        /// </summary>
        public long Cfk_Info { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string Info_Account { get; set; }

        /// <summary>
        /// 使用者姓名
        /// </summary>
        public string Info_Name { get; set; }
    }
}