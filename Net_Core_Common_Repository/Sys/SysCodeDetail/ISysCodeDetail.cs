using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysCodeDetail;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysCodeDetail
{
    /// <summary>
    /// 系統代碼檔(代碼明細)
    /// </summary>
    public interface ISysCodeDetail
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysCodeDetail_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysCodeDetail, int, string) fnInsert(CIn_SysCodeDetail_PageData oCIn_SysCodeDetail_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_SysCodeDetail_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysCodeDetail, int, string) fnUpdate(CIn_SysCodeDetail_Update oCIn_SysCodeDetail_Update, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="sClassPk">類別代號</param>
        /// <param name="sCodePk">代碼代號</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(string sClassPk, string sCodePk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_SysCodeDetail_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysCodeDetail>, string) fnGet(CIn_SysCodeDetail_Search oCIn_SysCodeDetail_Search);
    }
}