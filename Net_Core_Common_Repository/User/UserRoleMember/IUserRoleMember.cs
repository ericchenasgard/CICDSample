using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserRoleMember;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserRoleMember
{
    /// <summary>
    /// 使用者角色成員
    /// </summary>
    public interface IUserRoleMember
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserRoleMember_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRoleMember, int, string) fnInsert(CIn_UserRoleMember_PageData oCIn_UserRoleMember_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">資料PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lPk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_UserRoleMember_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserRoleMember>, string) fnGet(CIn_UserRoleMember_Search oCIn_UserRoleMember_Search);

        /// <summary>
        /// 取得資料 (包含：角色名稱&使用者名稱)
        /// </summary>
        /// <param name="oCIn_UserRoleMember_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<COut_UserRoleInfoName>, string) fnGetName(CIn_UserRoleMember_Search oCIn_UserRoleMember_Search);
    }
}