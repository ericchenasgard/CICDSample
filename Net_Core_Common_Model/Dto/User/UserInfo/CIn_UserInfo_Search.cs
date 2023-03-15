namespace Net_Core_Common_Model.Dto.User.UserInfo
{
    /// <summary>
    /// 使用者資訊-查詢欄位
    /// </summary>
    public class CIn_UserInfo_Search
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        public long? Pk_Info { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string? Info_Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string? Info_Name { get; set; }

        /// <summary>
        /// 帳號類別
        /// </summary>
        public string? Info_IsAd { get; set; }

        /// <summary>
        /// 狀態(0:停用，1:啟用)
        /// </summary>
        public string? Info_State { get; set; }
    }
}