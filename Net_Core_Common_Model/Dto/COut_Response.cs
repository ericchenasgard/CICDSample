namespace Net_Core_Common_Model.Dto
{
    /// <summary>
    /// 資料回傳格式(所有資料回傳都用此格式)
    /// </summary>
    public class COut_Response
    {
        /// <summary>
        /// 回傳資料
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 回傳狀態 (0:失敗/1:成功)
        /// </summary>
        public string Status { get; set; }
    }
}
