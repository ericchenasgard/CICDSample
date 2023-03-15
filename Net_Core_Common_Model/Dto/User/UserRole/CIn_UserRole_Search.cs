namespace Net_Core_Common_Model.Dto.User.UserRole
{
    /// <summary>
    /// 使用者角色設定-查詢欄位
    /// </summary>
    public class CIn_UserRole_Search
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        public long? Pk_Role { get; set; }

        /// <summary>
        /// 角色名稱
        /// </summary>
        public string? Role_Name { get; set; }

        /// <summary>
        /// 狀態(0:停用，1:啟用)
        /// </summary>
        public string? Role_State { get; set; }
    }
}