using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserInfo;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserInfo
{
    /// <summary>
    /// 使用者資訊
    /// </summary>
    public interface IUserInfo
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserInfo_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserInfo, int, string) fnInsert(CIn_UserInfo_PageData oCIn_UserInfo_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_UserInfo_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserInfo, int, string) fnUpdate(CIn_UserInfo_Update oCIn_UserInfo_Update, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">資料PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lPk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_UserInfo_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserInfo>, string) fnGet(CIn_UserInfo_Search oCIn_UserInfo_Search);
    }
}