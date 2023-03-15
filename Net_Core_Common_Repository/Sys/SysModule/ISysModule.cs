using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysModule;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysModule
{
    /// <summary>
    /// 選單作業
    /// </summary>
    public interface ISysModule
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysModule_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysModule, int, string) fnInsert(CIn_SysModule_PageData oCIn_SysModule_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_SysModule_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysModule, int, string) fnUpdate(CIn_SysModule_Update oCIn_SysModule_Update, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">資料PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lPk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_SysModule_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysModule>, string) fnGet(CIn_SysModule_Search oCIn_SysModule_Search);
    }
}