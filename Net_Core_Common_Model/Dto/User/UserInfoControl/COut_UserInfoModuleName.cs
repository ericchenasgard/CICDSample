namespace Net_Core_Common_Model.Dto.User.UserRoleMember
{
    /// <summary>
    /// 使用者角色名稱&使用者名稱
    /// </summary>
    public class COut_UserInfoModuleName
    {
        /// <summary>
        /// 使用者主鍵
        /// </summary>
        public long Cfk_Info { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string Info_Account { get; set; }

        /// <summary>
        /// 選單作業主鍵
        /// </summary>
        public long Cfk_Module { get; set; }

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
        /// 選單作業控制項
        /// </summary>
        public string Cfk_ModuleControl { get; set; }
    }
}