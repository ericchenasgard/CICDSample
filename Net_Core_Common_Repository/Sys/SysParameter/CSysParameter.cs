using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysParameter;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.Sys;

namespace Net_Core_Common_Repository.Sys.SysParameter
{
    /// <summary>
    /// 系統參數檔
    /// </summary>
    public class CSysParameter : ISysParameter
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CSysParameter(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_SysParameter_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysParameter, int, string) fnInsert(CIn_SysParameter_PageData oCIn_SysParameter_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_SysParameter oCTab_SysParameter = new CTab_SysParameter();

            // 回傳訊息
            string sMessage = "";

            try
            {
                #region 建立者、異動者資訊
                oCTab_SysParameter.Par_CreateId = oCOut_UserInfo.sCreateId;
                oCTab_SysParameter.Par_CreateDate = oCOut_UserInfo.dCreateDate;
                oCTab_SysParameter.Par_CreateIp = oCOut_UserInfo.sCreateIp;
                oCTab_SysParameter.Par_EditId = oCOut_UserInfo.sCreateId;
                oCTab_SysParameter.Par_EditDate = oCOut_UserInfo.dCreateDate;
                oCTab_SysParameter.Par_EditIp = oCOut_UserInfo.sCreateIp;
                #endregion

                // 組合新增的資料
                this._oCEntityContext.CTab_SysParameter.Add(oCTab_SysParameter).CurrentValues.SetValues(oCIn_SysParameter_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysParameter, iRT, sMessage);
        }
        #endregion

        #region 更新資料
        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_SysParameter_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_SysParameter, int, string) fnUpdate(CIn_SysParameter_Update oCIn_SysParameter_Update, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 更新的資料
            CTab_SysParameter oCTab_SysParameter = new CTab_SysParameter();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要更新的那筆資料
                var vUpdate = (from ta in this._oCEntityContext.CTab_SysParameter
                               where ta.Ck_Par_Group == oCIn_SysParameter_Update.Ck_Par_Group
                               && ta.Ck_Par_Code == oCIn_SysParameter_Update.Ck_Par_Code
                               select ta).SingleOrDefault();

                // 定義更新的資料
                if (vUpdate != null)
                {
                    vUpdate.Par_Name = oCIn_SysParameter_Update.Par_Name;
                    vUpdate.Par_State = oCIn_SysParameter_Update.Par_State;
                    vUpdate.Par_Value1 = oCIn_SysParameter_Update.Par_Value1;
                    vUpdate.Par_Value2 = oCIn_SysParameter_Update.Par_Value2;
                    vUpdate.Par_Value3 = oCIn_SysParameter_Update.Par_Value3;
                    vUpdate.Par_Value4 = oCIn_SysParameter_Update.Par_Value4;
                    vUpdate.Par_Value5 = oCIn_SysParameter_Update.Par_Value5;
                    vUpdate.Par_Value6 = oCIn_SysParameter_Update.Par_Value6;
                    vUpdate.Par_Value7 = oCIn_SysParameter_Update.Par_Value7;
                    vUpdate.Par_Value8 = oCIn_SysParameter_Update.Par_Value8;
                    vUpdate.Par_Value9 = oCIn_SysParameter_Update.Par_Value9;
                    vUpdate.Par_Value10 = oCIn_SysParameter_Update.Par_Value10;
                    vUpdate.Par_Remarks = oCIn_SysParameter_Update.Par_Remarks;

                    vUpdate.Par_EditId = oCOut_UserInfo.sCreateId;
                    vUpdate.Par_EditDate = oCOut_UserInfo.dCreateDate;
                    vUpdate.Par_EditIp = oCOut_UserInfo.sCreateIp;

                    // 執行更新
                    iRT = this._oCEntityContext.SaveChanges();

                    if (iRT > 0)
                    {
                        oCTab_SysParameter = vUpdate;
                    }
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_SysParameter, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="sGroupPk">參數群組</param>
        /// <param name="sCodePk">參數編號</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(string sGroupPk, string sCodePk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_SysParameter
                               where ta.Ck_Par_Group == sGroupPk
                               && ta.Ck_Par_Code == sCodePk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_SysParameter.RemoveRange(vDelete);

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
        /// <param name="oCIn_SysParameter_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_SysParameter>, string) fnGet(CIn_SysParameter_Search oCIn_SysParameter_Search)
        {
            // 查詢結果
            List<CTab_SysParameter> lCTab_SysParameter = new List<CTab_SysParameter>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_SysParameter
                          select ta;

                #region 查詢條件
                if (oCIn_SysParameter_Search.Ck_Par_Group != null)
                {
                    vRT = vRT.Where(x => x.Ck_Par_Group.Contains(oCIn_SysParameter_Search.Ck_Par_Group));
                }

                if (oCIn_SysParameter_Search.Ck_Par_Code != null)
                {
                    vRT = vRT.Where(x => x.Ck_Par_Code.Contains(oCIn_SysParameter_Search.Ck_Par_Code));
                }

                if (oCIn_SysParameter_Search.Par_Name != null)
                {
                    vRT = vRT.Where(x => x.Par_Name.Contains(oCIn_SysParameter_Search.Par_Name));
                }

                if (oCIn_SysParameter_Search.Par_State != null)
                {
                    vRT = vRT.Where(x => x.Par_State.Contains(oCIn_SysParameter_Search.Par_State));
                }
                #endregion

                lCTab_SysParameter = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_SysParameter, sMessage);
        }
        #endregion
    }
}