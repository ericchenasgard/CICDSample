using Net_Core_Common_Model.Dto;
using Net_Core_Common_Services.Define;
using Net_Core_Common_Services.Extension;

namespace Net_Core_Common_API.Method.SetResponse
{
    /// <summary>
    /// 設定一包回傳資料/訊息/狀態
    /// </summary>
    public class CSetResponse : ISetResponse
    {
        /// <summary>
        /// 設定一包回傳資料/訊息/狀態
        /// </summary>
        /// <param name="sOut_Data">要回傳的資料</param>
        /// <param name="sMessage">要回傳的訊息</param>
        /// <returns>要回傳的一包資料/訊息/狀態</returns>
        public COut_Response fnSetResponse(string sOut_Data, string sMessage)
        {
            // 回傳資料
            COut_Response cOut_Response = new COut_Response();

            cOut_Response.Data = sOut_Data;

            // 回傳訊息=""，代表成功
            if (sMessage == "")
            {
                cOut_Response.Message = ResponseCode.Code200.fnGetDescription();
                cOut_Response.Status = ((int)ResponseCode.Code200).ToString();
            }
            else
            {
                cOut_Response.Message = ResponseCode.Code500.fnGetDescription();
                cOut_Response.Status = ((int)ResponseCode.Code500).ToString();
            }

            return cOut_Response;
        }
    }
}
