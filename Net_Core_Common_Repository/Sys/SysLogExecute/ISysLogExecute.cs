using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysLogExecute;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysLogExecute
{
    /// <summary>
    /// 系統操作歷程
    /// </summary>
    public interface ISysLogExecute
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysLogExecute_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysLogExecute, int, string) fnInsert(CIn_SysLogExecute_PageData oCIn_SysLogExecute_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_SysLogExecute_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysLogExecute>, string) fnGet(CIn_SysLogExecute_Search oCIn_SysLogExecute_Search);
    }
}