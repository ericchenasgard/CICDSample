using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysCodeMain;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysCodeMain
{
    // / <summary>
    // / 系統代碼檔(代碼類別)
    // / </summary>
    public class CSysCodeMain : ISysCodeMain
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        // / <summary>
        // / 建構式
        // / </summary>
        // / <param name="oCEntityContext">資料庫實體</param>
        public CSysCodeMain(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        // / <summary>
        // / 新增資料
        // / </summary>
        // / <param name="oCIn_SysCodeMain_PageData">頁面資料</param>
        // / <param name="oCOut_UserInfo">使用者資訊</param>
        // / <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysCodeMain, int, string) fnInsert(CIn_SysCodeMain_PageData oCIn_SysCodeMain_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysCodeMain oCTab_SysCodeMain = new CTab_SysCodeMain();

            // 回傳訊息
            string sMessage = "";

            try
            {
                #region 建立者、異動者資訊
                oCTab_SysCodeMain.CodeMain_CreateId = oCOut_UserInfo.sCreateId;
                oCTab_SysCodeMain.CodeMain_CreateDate = oCOut_UserInfo.dCreateDate;
                oCTab_SysCodeMain.CodeMain_CreateIp = oCOut_UserInfo.sCreateIp;
                oCTab_SysCodeMain.CodeMain_EditId = oCOut_UserInfo.sCreateId;
                oCTab_SysCodeMain.CodeMain_EditDate = oCOut_UserInfo.dCreateDate;
                oCTab_SysCodeMain.CodeMain_EditIp = oCOut_UserInfo.sCreateIp;
                #endregion

                // 組合新增的資料
                this._oCEntityContext.CTab_SysCodeMain.Add(oCTab_SysCodeMain).CurrentValues.SetValues(oCIn_SysCodeMain_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysCodeMain, iRT, sMessage);
        }
        #endregion

        #region 更新資料
        // / <summary>
        // / 更新資料
        // / </summary>
        // / <param name="oCIn_SysCodeMain_Update">更新資料</param>
        // / <param name="oCOut_UserInfo">使用者資訊</param>
        // / <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysCodeMain, int, string) fnUpdate(CIn_SysCodeMain_Update oCIn_SysCodeMain_Update, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 更新的資料
            CTab_SysCodeMain oCTab_SysCodeMain = new CTab_SysCodeMain();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要更新的那筆資料
                var vUpdate = (from ta in this._oCEntityContext.CTab_SysCodeMain
                               where ta.Pk_CodeMain_Code == oCIn_SysCodeMain_Update.Pk_CodeMain_Code
                               select ta).SingleOrDefault();

                // 定義更新的資料
                if (vUpdate != null)
                {
                    vUpdate.CodeMain_Name = oCIn_SysCodeMain_Update.CodeMain_Name;
                    vUpdate.CodeMain_Remark = oCIn_SysCodeMain_Update.CodeMain_Remark;
                    vUpdate.CodeMain_State = oCIn_SysCodeMain_Update.CodeMain_State;

                    vUpdate.CodeMain_EditId = oCOut_UserInfo.sCreateId;
                    vUpdate.CodeMain_EditDate = oCOut_UserInfo.dCreateDate;
                    vUpdate.CodeMain_EditIp = oCOut_UserInfo.sCreateIp;

                    // 執行更新
                    iRT = this._oCEntityContext.SaveChanges();

                    if (iRT > 0)
                    {
                        oCTab_SysCodeMain = vUpdate;
                    }
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysCodeMain, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="sPk">資料PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(string sPk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_SysCodeMain
                               where ta.Pk_CodeMain_Code == sPk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_SysCodeMain.RemoveRange(vDelete);

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
        /// <param name="oCIn_SysCodeMain_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysCodeMain>, string) fnGet(CIn_SysCodeMain_Search oCIn_SysCodeMain_Search)
        {
            // 查詢結果
            List<CTab_SysCodeMain> lCTab_SysCodeMain = new List<CTab_SysCodeMain>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_SysCodeMain
                          select ta;

                #region 查詢條件
                if (oCIn_SysCodeMain_Search.Pk_CodeMain_Code != null)
                {
                    vRT = vRT.Where(x => x.Pk_CodeMain_Code.Contains(oCIn_SysCodeMain_Search.Pk_CodeMain_Code));
                }

                if (oCIn_SysCodeMain_Search.CodeMain_Name != null)
                {
                    vRT = vRT.Where(x => x.CodeMain_Name.Contains(oCIn_SysCodeMain_Search.CodeMain_Name));
                }

                if (oCIn_SysCodeMain_Search.CodeMain_State != null)
                {
                    vRT = vRT.Where(x => x.CodeMain_State.Contains(oCIn_SysCodeMain_Search.CodeMain_State));
                }
                #endregion

                lCTab_SysCodeMain = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_SysCodeMain, sMessage);
        }
        #endregion
    }
}