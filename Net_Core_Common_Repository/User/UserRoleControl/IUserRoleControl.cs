using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserRoleControl;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserRoleControl
{
    /// <summary>
    /// 使用者角色作業控制項權限
    /// </summary>
    public interface IUserRoleControl
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserRoleControl_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserRoleControl, int, string) fnInsert(CIn_UserRoleControl_PageData oCIn_UserRoleControl_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lRolePk">使用者PK</param>
        /// <param name="lModulePk">選單作業PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDeletef(long lRolePk, long lModulePk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_UserRoleControl_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserRoleControl>, string) fnGet(CIn_UserRoleControl_Search oCIn_UserRoleControl_Search);

        /// <summary>
        /// 取得資料 (包含：使用者角色&模組代號&控制項代號)
        /// </summary>
        /// <param name="sRole">登入帳號</param>
        /// <param name="sModule">呼叫API：模組代號</param>
        /// <param name="sControl">呼叫API：控制項代號</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (bool, string) fnGetName(string sRole, string sModule, string sControl);
    }
}