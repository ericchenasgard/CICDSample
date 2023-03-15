using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysModuleClass;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysModuleClass
{
    /// <summary>
    /// 選單分類
    /// </summary>
    public class CSysModuleClass : ISysModuleClass
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CSysModuleClass(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysModuleClass_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數</returns>
        public (CTab_SysModuleClass, int, string) fnInsert(CIn_SysModuleClass_PageData oCIn_SysModuleClass_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysModuleClass oCTab_SysModuleClass = new CTab_SysModuleClass();

            // 回傳訊息
            string sMessage = "";

            try
            {
                #region 建立者、異動者資訊
                oCTab_SysModuleClass.ModClass_CreateId = oCOut_UserInfo.sCreateId;
                oCTab_SysModuleClass.ModClass_CreateDate = oCOut_UserInfo.dCreateDate;
                oCTab_SysModuleClass.ModClass_CreateIp = oCOut_UserInfo.sCreateIp;
                oCTab_SysModuleClass.ModClass_EditId = oCOut_UserInfo.sCreateId;
                oCTab_SysModuleClass.ModClass_EditDate = oCOut_UserInfo.dCreateDate;
                oCTab_SysModuleClass.ModClass_EditIp = oCOut_UserInfo.sCreateIp;
                #endregion

                // 組合新增的資料
                this._oCEntityContext.CTab_SysModuleClass.Add(oCTab_SysModuleClass).CurrentValues.SetValues(oCIn_SysModuleClass_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysModuleClass, iRT, sMessage);
        }
        #endregion

        #region 更新資料
        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_SysModuleClass_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數</returns>
        public (CTab_SysModuleClass, int, string) fnUpdate(CIn_SysModuleClass_Update oCIn_SysModuleClass_Update, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 更新的資料
            CTab_SysModuleClass oCTab_SysModuleClass = new CTab_SysModuleClass();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要更新的那筆資料
                var vUpdate = (from ta in this._oCEntityContext.CTab_SysModuleClass
                               where ta.Pk_ModuleClass == oCIn_SysModuleClass_Update.Pk_ModuleClass
                               select ta).SingleOrDefault();

                // 定義更新的資料
                if (vUpdate != null)
                {
                    vUpdate.ModClass_Parent = oCIn_SysModuleClass_Update.ModClass_Parent;
                    vUpdate.ModClass_Name = oCIn_SysModuleClass_Update.ModClass_Name;
                    vUpdate.ModClass_order = oCIn_SysModuleClass_Update.ModClass_order;
                    vUpdate.ModClass_State = oCIn_SysModuleClass_Update.ModClass_State;

                    vUpdate.ModClass_EditId = oCOut_UserInfo.sCreateId;
                    vUpdate.ModClass_EditDate = oCOut_UserInfo.dCreateDate;
                    vUpdate.ModClass_EditIp = oCOut_UserInfo.sCreateIp;

                    // 執行更新
                    iRT = this._oCEntityContext.SaveChanges();

                    if (iRT > 0)
                    {
                        oCTab_SysModuleClass = vUpdate;
                    }
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysModuleClass, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">資料PK</param>
        /// <returns>成功執行的筆數</returns>
        public (int, string) fnDelete(long lPk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_SysModuleClass
                               where ta.Pk_ModuleClass == lPk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_SysModuleClass.RemoveRange(vDelete);

                    // 執行刪除
                    iRT = this._oCEntityContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (iRT, sMessage);
        }
        #endregion

        #region 取得資料
        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_SysModuleClass_Search">查詢條件</param>
        /// <returns>查詢結果</returns>
        public (List<CTab_SysModuleClass>, string) fnGet(CIn_SysModuleClass_Search oCIn_SysModuleClass_Search)
        {
            // 查詢結果
            List<CTab_SysModuleClass> lCTab_SysModuleClass = new List<CTab_SysModuleClass>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_SysModuleClass
                          select ta;

                #region 查詢條件
                if (oCIn_SysModuleClass_Search.Pk_ModuleClass != null)
                {
                    vRT = vRT.Where(x => x.Pk_ModuleClass == oCIn_SysModuleClass_Search.Pk_ModuleClass);
                }

                if (oCIn_SysModuleClass_Search.ModClass_Name != null)
                {
                    vRT = vRT.Where(x => x.ModClass_Name.Contains(oCIn_SysModuleClass_Search.ModClass_Name));
                }

                if (oCIn_SysModuleClass_Search.ModClass_State != null)
                {
                    vRT = vRT.Where(x => x.ModClass_State.Contains(oCIn_SysModuleClass_Search.ModClass_State));
                }
                #endregion

                lCTab_SysModuleClass = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_SysModuleClass, sMessage);
        }
        #endregion
    }
}