using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserInfoPassword;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserInfoPassword
{
    /// <summary>
    /// 使用者密碼變更記錄
    /// </summary>
    public interface IUserInfoPassword
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserInfoPassword_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserInfoPassword, int, string) fnInsert(CIn_UserInfoPassword_PageData oCIn_UserInfoPassword_PageData, COut_UserInfo oCOut_UserInfo);
    }
}