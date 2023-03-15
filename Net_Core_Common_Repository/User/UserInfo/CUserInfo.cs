using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserInfo;
using Net_Core_Common_Model.Entity;
using Net_Core_Common_Model.Entity.User;

namespace Net_Core_Common_Repository.User.UserInfo
{
    /// <summary>
    /// 使用者資訊
    /// </summary>
    public class CUserInfo : IUserInfo
    {
        private readonly CEntityContext _oCEntityContext;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oCEntityContext">資料庫實體</param>
        public CUserInfo(CEntityContext oCEntityContext)
        {
            this._oCEntityContext = oCEntityContext;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserInfo_PageData">頁面資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>新增的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserInfo, int, string) fnInsert(CIn_UserInfo_PageData oCIn_UserInfo_PageData, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 新增的資料
            CTab_UserInfo oCTab_UserInfo = new CTab_UserInfo();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 有效日期(起/迄)
                oCTab_UserInfo.Info_StartDate = DateTime.Now;
                oCTab_UserInfo.Info_EndDate = DateTime.MaxValue;

                #region 建立者、異動者資訊
                oCTab_UserInfo.Info_CreateId = oCOut_UserInfo.sCreateId;
                oCTab_UserInfo.Info_CreateDate = oCOut_UserInfo.dCreateDate;
                oCTab_UserInfo.Info_CreateIp = oCOut_UserInfo.sCreateIp;
                oCTab_UserInfo.Info_EditId = oCOut_UserInfo.sCreateId;
                oCTab_UserInfo.Info_EditDate = oCOut_UserInfo.dCreateDate;
                oCTab_UserInfo.Info_EditIp = oCOut_UserInfo.sCreateIp;
                #endregion

                // 組合新增的資料
                this._oCEntityContext.CTab_UserInfo.Add(oCTab_UserInfo).CurrentValues.SetValues(oCIn_UserInfo_PageData);

                // 執行新增
                iRT = this._oCEntityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserInfo, iRT, sMessage);
        }
        #endregion

        #region 更新資料
        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_UserInfo_Update">更新資料</param>
        /// <param name="oCOut_UserInfo">使用者資訊</param>
        /// <returns>更新的資料/成功執行的筆數/回傳訊息</returns>
        public (CTab_UserInfo, int, string) fnUpdate(CIn_UserInfo_Update oCIn_UserInfo_Update, COut_UserInfo oCOut_UserInfo)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 更新的資料
            CTab_UserInfo oCTab_UserInfo = new CTab_UserInfo();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要更新的那筆資料
                var vUpdate = (from ta in this._oCEntityContext.CTab_UserInfo
                               where ta.Pk_Info == oCIn_UserInfo_Update.Pk_Info
                               select ta).SingleOrDefault();

                // 定義更新的資料
                if (vUpdate != null)
                {
                    vUpdate.Info_IsAd = oCIn_UserInfo_Update.Info_IsAd;
                    vUpdate.Info_IsAdmin = oCIn_UserInfo_Update.Info_IsAdmin;
                    vUpdate.Info_Name = oCIn_UserInfo_Update.Info_Name;
                    vUpdate.Info_Email = oCIn_UserInfo_Update.Info_Email;
                    vUpdate.Info_Account = oCIn_UserInfo_Update.Info_Account;
                    vUpdate.Info_AccountAd = oCIn_UserInfo_Update.Info_AccountAd;
                    vUpdate.Info_Password = oCIn_UserInfo_Update.Info_Password;
                    vUpdate.Info_Lock = oCIn_UserInfo_Update.Info_Lock;
                    vUpdate.Info_State = oCIn_UserInfo_Update.Info_State;
                    vUpdate.Info_Disable = oCIn_UserInfo_Update.Info_Disable;
                    vUpdate.Info_DisableReason = oCIn_UserInfo_Update.Info_DisableReason;

                    vUpdate.Info_EditId = oCOut_UserInfo.sCreateId;
                    vUpdate.Info_EditDate = oCOut_UserInfo.dCreateDate;
                    vUpdate.Info_EditIp = oCOut_UserInfo.sCreateIp;

                    // 執行更新
                    iRT = this._oCEntityContext.SaveChanges();

                    if (iRT > 0)
                    {
                        oCTab_UserInfo = vUpdate;
                    }
                }
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (oCTab_UserInfo, iRT, sMessage);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">資料PK</param>
        /// <returns>成功執行的筆數/回傳訊息</returns>
        public (int, string) fnDelete(long lPk)
        {
            // 成功執行的筆數
            int iRT = 0;

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 取得要刪除的那筆資料
                var vDelete = (from ta in this._oCEntityContext.CTab_UserInfo
                               where ta.Pk_Info == lPk
                               select ta).SingleOrDefault();

                if (vDelete != null)
                {
                    // 可刪除多筆
                    this._oCEntityContext.CTab_UserInfo.RemoveRange(vDelete);

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
        /// <param name="oCIn_UserInfo_Search">查詢條件</param>
        /// <returns>查詢結果/回傳訊息</returns>
        public (List<CTab_UserInfo>, string) fnGet(CIn_UserInfo_Search oCIn_UserInfo_Search)
        {
            // 查詢結果
            List<CTab_UserInfo> lCTab_UserInfo = new List<CTab_UserInfo>();

            // 回傳訊息
            string sMessage = "";

            try
            {
                // 查詢全部
                var vRT = from ta in this._oCEntityContext.CTab_UserInfo
                          select ta;

                #region 查詢條件
                if (oCIn_UserInfo_Search.Pk_Info != null)
                {
                    vRT = vRT.Where(x => x.Pk_Info == oCIn_UserInfo_Search.Pk_Info);
                }

                if (oCIn_UserInfo_Search.Info_Account != null)
                {
                    vRT = vRT.Where(x => x.Info_Account.Contains(oCIn_UserInfo_Search.Info_Account));
                }

                if (oCIn_UserInfo_Search.Info_Name != null)
                {
                    vRT = vRT.Where(x => x.Info_Name.Contains(oCIn_UserInfo_Search.Info_Name));
                }

                if (oCIn_UserInfo_Search.Info_IsAd != null)
                {
                    vRT = vRT.Where(x => x.Info_IsAd.Contains(oCIn_UserInfo_Search.Info_IsAd));
                }

                if (oCIn_UserInfo_Search.Info_State != null)
                {
                    vRT = vRT.Where(x => x.Info_State.Contains(oCIn_UserInfo_Search.Info_State));
                }
                #endregion

                lCTab_UserInfo = vRT.ToList();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return (lCTab_UserInfo, sMessage);
        }
        #endregion
    }
}