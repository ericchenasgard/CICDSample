using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysCodeMain;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysCodeMain
{
    /// <summary>
    /// 系統代碼檔(代碼類別)
    /// </summary>
    public interface ISysCodeMain
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysCodeMain_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysCodeMain, int, string) fnInsert(CIn_SysCodeMain_PageData oCIn_SysCodeMain_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_SysCodeMain_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysCodeMain, int, string) fnUpdate(CIn_SysCodeMain_Update oCIn_SysCodeMain_Update, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="sPk">資料PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(string sPk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_SysCodeMain_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysCodeMain>, string) fnGet(CIn_SysCodeMain_Search oCIn_SysCodeMain_Search);
    }
}