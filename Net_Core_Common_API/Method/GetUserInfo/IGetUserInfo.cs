using Net_Core_Common_Model.Dto;

namespace Net_Core_Common_API.Method.GetUserInfo
{
    /// <summary>
    /// 取得使用者資訊
    /// </summary>
    public interface IGetUserInfo
    {
        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <returns>使用者資訊</returns>
        public COut_UserInfo fnGetUserInfo();
    }
}
