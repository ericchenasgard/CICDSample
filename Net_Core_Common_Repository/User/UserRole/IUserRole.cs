using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserRole;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserRole
{
    /// <summary>
    /// 使用者角色設定
    /// </summary>
    public interface IUserRole
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserRole_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRole, int, string) fnInsert(CIn_UserRole_PageData oCIn_UserRole_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_UserRole_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRole, int, string) fnUpdate(CIn_UserRole_Update oCIn_UserRole_Update, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">資料PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lPk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_UserRole_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserRole>, string) fnGet(CIn_UserRole_Search oCIn_UserRole_Search);
    }
}