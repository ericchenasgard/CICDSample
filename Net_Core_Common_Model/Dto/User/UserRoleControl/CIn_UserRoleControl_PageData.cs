namespace Net_Core_Common_Model.Dto.User.UserRoleControl
{
    /// <summary>
    /// 使用者角色作業控制項權限-畫面欄位
    /// </summary>
    public class CIn_UserRoleControl_PageData
    {
        //// <summary>
        /// 使用者角色主鍵
        /// </summary>
        public long Cfk_Role { get; set; }

        /// <summary>
        /// 選單作業主鍵
        /// </summary>
        public long Cfk_Module { get; set; }

        /// <summary>
        /// 選單作業控制項
        /// </summary>
        public string Cfk_ModCon_Code { get; set; }
    }
}