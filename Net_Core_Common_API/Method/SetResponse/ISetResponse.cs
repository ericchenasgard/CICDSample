using Net_Core_Common_Model.Dto;

namespace Net_Core_Common_API.Method.SetResponse
{
    /// <summary>
    /// 設定一包回傳資料/訊息/狀態
    /// </summary>
    public interface ISetResponse
    {
        /// <summary>
        /// 設定一包回傳資料/訊息/狀態
        /// </summary>
        /// <param name="sOut_Data">要回傳的資料</param>
        /// <param name="sMessage">要回傳的訊息</param>
        /// <returns>要回傳的一包資料/訊息/狀態</returns>
        public COut_Response fnSetResponse(string sOut_Data, string sMessage);
    }
}
