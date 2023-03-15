using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserInfoAuth;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserInfoAuth
{
    /// <summary>
    /// 使用者作業權限
    /// </summary>
    public interface IUserInfoAuth
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserInfoAuth_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數</returns>
        public (CTab_UserInfoAuth, int, string) fnInsert(CIn_UserInfoAuth_PageData oCIn_UserInfoAuth_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lInfoPk">使用者PK</param>
        /// <param name="lModulePk">選單作業PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lInfoPk, long lModulePk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_UserInfoAuth_Search">查詢條件</param>
        /// <returns>查詢結果</returns>
        public (List<CTab_UserInfoAuth>, string) fnGet(CIn_UserInfoAuth_Search oCIn_UserInfoAuth_Search);
    }
}