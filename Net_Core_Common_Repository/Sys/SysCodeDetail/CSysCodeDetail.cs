using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysCodeDetail;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysCodeDetail
{
    /// <summary>
    /// 系統代碼檔(代碼明細)
    /// </summary>
    public class CSysCodeDetail : ISysCodeDetail
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CSysCodeDetail(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysCodeDetail_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysCodeDetail, int, string) fnInsert(CIn_SysCodeDetail_PageData oCIn_SysCodeDetail_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysCodeDetail oCTab_SysCodeDetail = new CTab_SysCodeDetail();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 組合新增的資料
                this._oCEntityContext.CTab_SysCodeDetail.Add(oCTab_SysCodeDetail).CurrentValues.SetValues(oCIn_SysCodeDetail_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysCodeDetail, iRT, sMessage);
        }
        #endregion

        #region 更新資料
        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_SysCodeDetail_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysCodeDetail, int, string) fnUpdate(CIn_SysCodeDetail_Update oCIn_SysCodeDetail_Update, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 更新的資料
            CTab_SysCodeDetail oCTab_SysCodeDetail = new CTab_SysCodeDetail();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要更新的那筆資料
                var vUpdate = (from ta in this._oCEntityContext.CTab_SysCodeDetail
                               where ta.Cfk_CodeMain_Code == oCIn_SysCodeDetail_Update.Cfk_CodeMain_Code
                               && ta.Ck_CodeDet_Code == oCIn_SysCodeDetail_Update.Ck_CodeDet_Code
                               select ta).SingleOrDefault();

                // 定義更新的資料
                if (vUpdate != null)
                {
                    vUpdate.Ck_CodeDet_Code = oCIn_SysCodeDetail_Update.Ck_CodeDet_Code;
                    vUpdate.CodeDet_Name = oCIn_SysCodeDetail_Update.CodeDet_Name;
                    vUpdate.CodeDet_Remark = oCIn_SysCodeDetail_Update.CodeDet_Remark;
                    vUpdate.CodeDet_State = oCIn_SysCodeDetail_Update.CodeDet_State;

                    // 執行更新
                    iRT = this._oCEntityContext.SaveChanges();

                    if (iRT > 0)
                    {
                        oCTab_SysCodeDetail = vUpdate;
                    }
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysCodeDetail, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="sClassPk">類別代號</param>
        /// <param name="sCodePk">代碼代號</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(string sClassPk, string sCodePk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_SysCodeDetail
                               where ta.Cfk_CodeMain_Code == sClassPk && ta.Ck_CodeDet_Code == sCodePk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_SysCodeDetail.RemoveRange(vDelete);

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
        /// <param name="oCIn_SysCodeDetail_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysCodeDetail>, string) fnGet(CIn_SysCodeDetail_Search oCIn_SysCodeDetail_Search)
        {
            // 查詢結果
            List<CTab_SysCodeDetail> lCTab_SysCodeDetail = new List<CTab_SysCodeDetail>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_SysCodeDetail
                          select ta;

                #region 查詢條件
                if (oCIn_SysCodeDetail_Search.Cfk_CodeMain_Code != null)
                {
                    vRT = vRT.Where(x => x.Cfk_CodeMain_Code.Contains(oCIn_SysCodeDetail_Search.Cfk_CodeMain_Code));
                }

                if (oCIn_SysCodeDetail_Search.Ck_CodeDet_Code != null)
                {
                    vRT = vRT.Where(x => x.Ck_CodeDet_Code.Contains(oCIn_SysCodeDetail_Search.Ck_CodeDet_Code));
                }

                if (oCIn_SysCodeDetail_Search.CodeDet_Name != null)
                {
                    vRT = vRT.Where(x => x.CodeDet_Name.Contains(oCIn_SysCodeDetail_Search.CodeDet_Name));
                }

                if (oCIn_SysCodeDetail_Search.CodeDet_State != null)
                {
                    vRT = vRT.Where(x => x.CodeDet_State.Contains(oCIn_SysCodeDetail_Search.CodeDet_State));
                }
                #endregion

                lCTab_SysCodeDetail = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_SysCodeDetail, sMessage);
        }
        #endregion
    }
}