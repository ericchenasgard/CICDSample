using Microsoft.AspNetCore.Mvc;
using Net_Core_Common_API.Method.GetUserInfo;
using Net_Core_Common_API.Method.SetResponse;
using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.User.UserRole;
using Net_Core_Common_Repository.User.UserRole;
using Net_Core_Common_Services.Public.DoJson;
using Net_Core_Common_Services.Public.DoNLog;

namespace Net_Core_Common_API.Controllers.User
{
    /// <summary>
    /// 使用者角色設定
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        /// <summary>
        /// 執行NLog記錄
        /// </summary>
        private readonly IDoNLog _oIDoNLog;

        /// <summary>
        /// Json序列化-物件
        /// </summary>
        private readonly IDoJson _oIDoJson;

        /// <summary>
        /// 回傳資料/訊息/狀態
        /// </summary>
        private readonly ISetResponse _oISetResponse;

        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        private readonly IGetUserInfo _oIGetUserInfo;

        /// <summary>
        /// 使用者角色設定
        /// </summary>
        private readonly IUserRole _oIUserRole;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oIDoNLog">執行NLog記錄</param>
        /// <param name="oIDoJson">Json序列化</param>
        /// <param name="oISetResponse">回傳資料/訊息/狀態</param>
        /// <param name="oIGetUserInfo">取得使用者資訊</param>
        /// <param name="oIUserRole">選單作業</param>
        public UserRoleController(IDoNLog oIDoNLog, IDoJson oIDoJson, ISetResponse oISetResponse, IGetUserInfo oIGetUserInfo, IUserRole oIUserRole)
        {
            this._oIDoNLog = oIDoNLog;
            this._oIDoJson = oIDoJson;
            this._oISetResponse = oISetResponse;
            this._oIGetUserInfo = oIGetUserInfo;
            this._oIUserRole = oIUserRole;
        }
        #endregion

        #region 新增資料
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="oCIn_UserRole_PageData">頁面資料</param>
        /// <returns>新增的資料</returns>
        [HttpPost("Create")]
        public ActionResult Create(CIn_UserRole_PageData oCIn_UserRole_PageData)
        {
            // 取得執行結果(回傳資料/成功筆數)
            var (oCTab_UserRole, iChange, sMessage) = this._oIUserRole.fnInsert(oCIn_UserRole_PageData, this._oIGetUserInfo.fnGetUserInfo());

            #region 回傳資料/訊息/狀態
            // 回傳資料
            string sOut_Data = this._oIDoJson.fnDoSerializeObject(oCTab_UserRole);

            #region 回傳訊息
            string sOut_Message = "";
            if (sMessage != "")
            {
                sOut_Message = sOut_Message + sMessage + "。";
            }
            #endregion

            COut_Response cOut_Response = this._oISetResponse.fnSetResponse(sOut_Data, sOut_Message);
            #endregion

            return new JsonResult(cOut_Response);
        }
        #endregion

        #region 更新資料
        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="oCIn_UserRole_Update">更新資料</param>
        /// <returns>更新的資料</returns>
        [HttpPost("Update")]
        public ActionResult Update(CIn_UserRole_Update oCIn_UserRole_Update)
        {
            // 取得執行結果(回傳資料/成功筆數)
            var (oCTab_UserRole, iChange, sMessage) = this._oIUserRole.fnUpdate(oCIn_UserRole_Update, this._oIGetUserInfo.fnGetUserInfo());

            #region 回傳資料/訊息/狀態
            // 回傳資料
            string sOut_Data = this._oIDoJson.fnDoSerializeObject(oCTab_UserRole);

            #region 回傳訊息
            string sOut_Message = "";
            if (sMessage != "")
            {
                sOut_Message = sOut_Message + sMessage + "。";
            }
            #endregion

            COut_Response cOut_Response = this._oISetResponse.fnSetResponse(sOut_Data, sOut_Message);
            #endregion

            return new JsonResult(cOut_Response);
        }
        #endregion

        #region 刪除資料
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="lPk">Pk</param>
        /// <returns>刪除筆數</returns>
        [HttpPost("Delete")]
        public ActionResult Delete(long lPk)
        {
            // 取得執行結果(成功筆數)
            var (iChange, sMessage) = this._oIUserRole.fnDelete(lPk);

            #region 回傳資料/訊息/狀態
            // 回傳資料
            string sOut_Data = "已刪除 " + iChange.ToString() + " 筆資料。";

            #region 回傳訊息
            string sOut_Message = "";
            if (sMessage != "")
            {
                sOut_Message = sOut_Message + sMessage + "。";
            }
            #endregion

            COut_Response cOut_Response = this._oISetResponse.fnSetResponse(sOut_Data, sOut_Message);
            #endregion

            return new JsonResult(cOut_Response);
        }
        #endregion

        #region 取得資料
        /// <summary>
        /// 取得資料-依查詢條件做查詢
        /// </summary>
        /// <param name="oCIn_UserRole_Search">查詢條件</param>
        /// <returns>查詢結果(可能是多筆)</returns>
        [HttpPost("Get")]
        public ActionResult Get([FromQuery] CIn_UserRole_Search oCIn_UserRole_Search)
        {
            // 取得執行結果(回傳資料)
            var (lCTab_UserRole, sMessage) = this._oIUserRole.fnGet(oCIn_UserRole_Search);

            #region 回傳資料/訊息/狀態
            // 回傳資料
            string sOut_Data = this._oIDoJson.fnDoSerializeObject(lCTab_UserRole);

            #region 回傳訊息
            string sOut_Message = "";
            if (sMessage != "")
            {
                sOut_Message = sOut_Message + sMessage + "。";
            }
            #endregion

            COut_Response cOut_Response = this._oISetResponse.fnSetResponse(sOut_Data, sOut_Message);
            #endregion

            return new JsonResult(cOut_Response);
        }
        #endregion
    }
}