using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysParameter;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysParameter
{
    /// <summary>
    /// 系統參數檔
    /// </summary>
    public interface ISysParameter
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysParameter_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysParameter, int, string) fnInsert(CIn_SysParameter_PageData oCIn_SysParameter_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_SysParameter_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysParameter, int, string) fnUpdate(CIn_SysParameter_Update oCIn_SysParameter_Update, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="sGroupPk">參數群組</param>
        /// <param name="sCodePk">參數編號</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(string sGroupPk, string sCodePk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_SysParameter_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysParameter>, string) fnGet(CIn_SysParameter_Search oCIn_SysParameter_Search);
    }
}