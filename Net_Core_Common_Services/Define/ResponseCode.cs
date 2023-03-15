using System.ComponentModel;

namespace Net_Core_Common_Services.Define
{
    /// <summary>
    /// 回傳代號：回傳訊息
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// 101：您的手機號碼已填寫過。
        /// </summary>
        [Description("您的手機號碼已填寫過。")]
        Code101 = 101,

        /// <summary>
        /// 102：寫入資料異常，請檢查資料格式是否確認。
        /// </summary>
        [Description("寫入資料異常，請檢查資料格式是否確認。")]
        Code102 = 102,

        /// <summary>
        /// 103：您的姓名不得為空。
        /// </summary>
        [Description("您的姓名不得為空。")]
        Code103 = 103,

        /// <summary>
        /// 104：您的姓名必須為中文。
        /// </summary>
        [Description("您的姓名必須為中文。")]
        Code104 = 104,

        /// <summary>
        /// 105：您的手機號碼不得為空。
        /// </summary>
        [Description("您的手機號碼不得為空。")]
        Code105 = 105,

        /// <summary>
        /// 106：您的生日格式有誤。
        /// </summary>
        [Description("您的生日格式有誤。")]
        Code106 = 106,

        /// <summary>
        /// 107：您的手機號碼前兩碼必須為09。
        /// </summary>
        [Description("您的手機號碼前兩碼必須為09。")]
        Code107 = 107,

        /// <summary>
        /// 108：您的手機號碼必須為數字。
        /// </summary>
        [Description("您的手機號碼必須為數字。")]
        Code108 = 108,

        /// <summary>
        /// 200：執行成功。
        /// </summary>
        [Description("執行成功。")]
        Code200 = 200,

        /// <summary>
        /// 400：格式或欄位驗證錯誤。
        /// </summary>
        [Description("格式或欄位驗證錯誤。")]
        Code400 = 400,

        /// <summary>
        /// 401：Token驗證失敗，請洽系統管理人員。
        /// </summary>
        [Description("Token驗證失敗，請洽系統管理人員。")]
        Code401 = 401,

        /// <summary>
        /// 401：終端授權失敗，請洽系統管理人員。
        /// </summary>
        [Description("終端授權失敗，請洽系統管理人員。")]
        Code403 = 403,

        /// <summary>
        /// 404：終端授權失敗，請洽系統管理人員。
        /// </summary>
        [Description("URL錯誤，請洽系統管理人員。")]
        Code404 = 404,

        /// <summary>
        /// 405：Request的Method錯誤。
        /// </summary>
        [Description("Request的Method錯誤。")]
        Code405 = 405,

        /// <summary>
        /// 415：Request的Content-Type錯誤。
        /// </summary>
        [Description("Request的Content-Type錯誤。")]
        Code415 = 415,

        /// <summary>
        /// 500：系統錯誤，請洽系統管理人員。
        /// </summary>
        [Description("系統錯誤，請洽系統管理人員。")]
        Code500 = 500,

        /// <summary>
        /// 500：網頁維護中，暫停使用! 很抱歉!目前本網頁緊急維護中造成您的不便，敬請見諒!
        /// </summary>
        [Description("網頁維護中，暫停使用! 很抱歉!目前本網頁緊急維護中造成您的不便，敬請見諒!")]
        Code501 = 501,

        /// <summary>
        /// 999：感謝您留下寶貴資料，會有專人為您服務。
        /// </summary>
        [Description("感謝您留下寶貴資料，會有專人為您服務。")]
        Code999 = 999
    }
}
