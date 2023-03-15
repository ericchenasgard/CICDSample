using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysModuleClass;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysModuleClass
{
    /// <summary>
    /// 選單分類
    /// </summary>
    public interface ISysModuleClass
    {
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysModuleClass_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數</returns>
        public (CTab_SysModuleClass, int, string) fnInsert(CIn_SysModuleClass_PageData oCIn_SysModuleClass_PageData, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_SysModuleClass_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數</returns>
        public (CTab_SysModuleClass, int, string) fnUpdate(CIn_SysModuleClass_Update oCIn_SysModuleClass_Update, COut_UserInfo oCOut_UserInfo);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">資料PK</param>
        /// <returns>成功執行的筆數</returns>
        public (int, string) fnDelete(long lPk);

        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_SysModuleClass_Search">查詢條件</param>
        /// <returns>查詢結果</returns>
        public (List<CTab_SysModuleClass>, string) fnGet(CIn_SysModuleClass_Search oCIn_SysModuleClass_Search);
    }
}