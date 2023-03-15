using Microsoft.AspNetCore.Mvc;
using Net_Core_Common_API.Method.SetResponse;
using Net_Core_Common_Model.Dto;
using Net_Core_Common_Model.Dto.Sys.SysModule;
using Net_Core_Common_Model.Dto.Sys.SysModuleClass;
using Net_Core_Common_Model.Dto.Sys.SysModuleControl;
using Net_Core_Common_Repository.Sys.SysModule;
using Net_Core_Common_Repository.Sys.SysModuleClass;
using Net_Core_Common_Repository.Sys.SysModuleControl;
using Net_Core_Common_Services.Public.DoJson;
using Net_Core_Common_Services.Public.DoNLog;

namespace Net_Core_Common_API.Controllers
{
    /// <summary>
    /// 選單樹
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTreeController : ControllerBase
    {
        /// <summary>
        /// 執行NLog記錄
        /// </summary>
        private readonly IDoNLog _oIDoNLog;

        /// <summary>
        /// Json序列化
        /// </summary>
        private readonly IDoJson _oIDoJson;

        /// <summary>
        /// 回傳資料/訊息/狀態
        /// </summary>
        private readonly ISetResponse _oISetResponse;

        /// <summary>
        /// 選單分類
        /// </summary>
        private readonly ISysModuleClass _oISysModuleClass;

        /// <summary>
        /// 選單作業
        /// </summary>
        private readonly ISysModule _oISysModule;

        /// <summary>
        /// 選單作業控制項
        /// </summary>
        private readonly ISysModuleControl _oISysModuleControl;

        #region 建構式
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="oIDoNLog">執行NLog記錄</param>
        /// <param name="oIDoJson">Json序列化</param>
        /// <param name="oISetResponse">回傳資料/訊息/狀態</param>
        /// <param name="oISysModuleClass">選單分類</param>
        /// <param name="oISysModule">選單作業</param>
        /// <param name="oISysModuleControl">選單權限控制</param>
        public MenuTreeController(IDoNLog oIDoNLog, IDoJson oIDoJson, ISetResponse oISetResponse, ISysModuleClass oISysModuleClass, ISysModule oISysModule, ISysModuleControl oISysModuleControl)
        {
            this._oIDoNLog = oIDoNLog;
            this._oIDoJson = oIDoJson;
            this._oISetResponse = oISetResponse;
            this._oISysModuleClass = oISysModuleClass;
            this._oISysModule = oISysModule;
            this._oISysModuleControl = oISysModuleControl;
        }
        #endregion

        #region 取得選單權限控制樹
        /// <summary>
        /// 取得選單權限控制樹
        /// </summary>
        /// <returns>查詢結果(單筆)</returns>
        [HttpPost("Get")]
        public ActionResult Get()
        {
            // 選單權限控制樹
            List<COut_ModelControl> lCOut_ModelControl = new List<COut_ModelControl>();

            #region 取得選單分類/父選單分類
            // 塞入查詢值
            CIn_SysModuleClass_Search oCIn_SysModuleClass_Search = new CIn_SysModuleClass_Search()
            {
                ModClass_State = "1",
            };

            // 取得選單分類
            var (lCTab_SysModuleClass, sClassMessage) = this._oISysModuleClass.fnGet(oCIn_SysModuleClass_Search);

            foreach (var oCTab_SysModuleClass in lCTab_SysModuleClass)
            {
                #region 選單分類的父選單PK
                string sModClass_Parent = "";
                if (oCTab_SysModuleClass.ModClass_Parent == null)
                {
                    sModClass_Parent = "99999";
                }
                else
                {
                    sModClass_Parent = oCTab_SysModuleClass.ModClass_Parent.ToString();
                }
                #endregion

                #region 選單權限控制
                COut_ModelControl oCOut_ModelControl = new COut_ModelControl();

                oCOut_ModelControl.Module_Pk = oCTab_SysModuleClass.Pk_ModuleClass.ToString();
                oCOut_ModelControl.Module_Name = oCTab_SysModuleClass.ModClass_Name;
                oCOut_ModelControl.Module_Parent = sModClass_Parent;
                oCOut_ModelControl.Module_order = oCTab_SysModuleClass.ModClass_order.ToString();
                oCOut_ModelControl.Module_Controls = null;
                #endregion

                lCOut_ModelControl.Add(oCOut_ModelControl);
            }
            #endregion

            #region 取得選單作業
            // 塞入查詢值
            CIn_SysModule_Search oCIn_SysModule_Search = new CIn_SysModule_Search()
            {
                Module_State = "1",
            };

            // 取得選單作業
            var (lCTab_SysModule, sModuleMessage) = this._oISysModule.fnGet(oCIn_SysModule_Search);

            foreach (var oCTab_SysModule in lCTab_SysModule)
            {
                #region 選單權限控制
                COut_ModelControl oCOut_ModelControl = new COut_ModelControl();

                oCOut_ModelControl.Module_Pk = "Mod_" + oCTab_SysModule.Pk_Module.ToString();
                oCOut_ModelControl.Module_Name = oCTab_SysModule.Module_Name;
                oCOut_ModelControl.Module_Parent = oCTab_SysModule.FK_ModuleClass.ToString();
                oCOut_ModelControl.Module_order = oCTab_SysModule.Module_order.ToString();

                #region 選單作業控制項
                // 塞入查詢值
                CIn_SysModuleControl_Search oCIn_SysModuleControl_Search = new CIn_SysModuleControl_Search()
                {
                    Cfk_Module = oCTab_SysModule.Pk_Module,
                };

                // 選單作業控制項
                var (lCTab_SysModuleControl, sControlMessage) = this._oISysModuleControl.fnGet(oCIn_SysModuleControl_Search);

                if (lCTab_SysModuleControl.Count > 0)
                {
                    oCOut_ModelControl.Module_Controls = new List<COut_SysModuleControl>();

                    foreach (var oCTab_SysModuleControl in lCTab_SysModuleControl)
                    {
                        COut_SysModuleControl oCOut_SysModuleControl = new COut_SysModuleControl();

                        oCOut_SysModuleControl.ModCon_Code = oCTab_SysModuleControl.ModCon_Code;
                        oCOut_SysModuleControl.ModCon_Name = oCTab_SysModuleControl.ModCon_Name;

                        oCOut_ModelControl.Module_Controls.Add(oCOut_SysModuleControl);
                    }
                }
                else
                {
                    oCOut_ModelControl.Module_Controls = null;
                }
                #endregion

                #endregion

                lCOut_ModelControl.Add(oCOut_ModelControl);
            }
            #endregion

            #region 回傳資料/訊息/狀態
            // 回傳資料
            string sOut_Data = this._oIDoJson.fnDoSerializeObject(lCOut_ModelControl);

            #region 回傳訊息
            string sOut_Message = "";
            if (sClassMessage != "")
            {
                sOut_Message = sOut_Message + sClassMessage + "。";
            }

            if (sModuleMessage != "")
            {
                sOut_Message = sOut_Message + sModuleMessage + "。";
            }
            #endregion

            COut_Response cOut_Response = this._oISetResponse.fnSetResponse(sOut_Data, sOut_Message);
            #endregion

            return new JsonResult(cOut_Response);
        }
        #endregion
    }
}