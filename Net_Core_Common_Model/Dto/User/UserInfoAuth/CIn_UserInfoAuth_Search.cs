namespace Net_Core_Common_Model.Dto.User.UserInfoAuth
{
    /// <summary>
    /// 使用者作業權限-查詢欄位
    /// </summary>
    public class CIn_UserInfoAuth_Search
    {
        /// <summary>
        /// 使用者主鍵
        /// </summary>
        public long? Cfk_Info { get; set; }

        /// <summary>
        /// 選單作業主鍵
        /// </summary>
        public long? Cfk_Module { get; set; }
    }
}