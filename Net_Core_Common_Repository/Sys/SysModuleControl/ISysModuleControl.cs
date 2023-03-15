using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysModuleControl;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysModuleControl
{
    /// <summary>
    /// 選單作業控制項
    /// </summary>
    public interface ISysModuleControl
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysModuleControl_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysModuleControl, int, string) fnInsert(CIn_SysModuleControl_PageData oCIn_SysModuleControl_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lModulePk">選單作業PK</param>
        /// <param name="sModControlPk">選單作業控制項PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lModulePk, string sModControlPk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_SysModuleControl_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysModuleControl>, string) fnGet(CIn_SysModuleControl_Search oCIn_SysModuleControl_Search);
    }
}