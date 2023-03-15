using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserInfoControl;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserInfoControl
{
    /// <summary>
    /// 使用者作業控制項權限
    /// </summary>
    public interface IUserInfoControl
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserInfoControl_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserInfoControl, int, string) fnInsert(CIn_UserInfoControl_PageData oCIn_UserInfoControl_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lInfoPk">使用者PK</param>
        /// <param name="lModulePk">選單作業PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDeletef(long lInfoPk, long lModulePk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_UserInfoControl_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserInfoControl>, string) fnGet(CIn_UserInfoControl_Search oCIn_UserInfoControl_Search);

        /// <summary>
        /// 取得資料 (包含：使用者帳號&模組代號&控制項代號)
        /// </summary>
        /// <param name="sAccount">登入帳號</param>
        /// <param name="sModule">呼叫API：模組代號</param>
        /// <param name="sControl">呼叫API：控制項代號</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (bool, string) fnGetName(string sAccount, string sModule, string sControl);
    }
}