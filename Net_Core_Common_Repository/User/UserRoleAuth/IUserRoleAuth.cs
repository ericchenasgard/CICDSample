using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserRoleAuth;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserRoleAuth
{
    /// <summary>
    /// 使用者角色作業權限
    /// </summary>
    public interface IUserRoleAuth
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserRoleAuth_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRoleAuth, int, string) fnInsert(CIn_UserRoleAuth_PageData oCIn_UserRoleAuth_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">資料PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lPk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_UserRoleAuth_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserRoleAuth>, string) fnGet(CIn_UserRoleAuth_Search oCIn_UserRoleAuth_Search);
    }
}