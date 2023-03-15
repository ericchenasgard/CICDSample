namespace Net_Core_Common_Services.Public.CheckIsChinese
{
    /// <summary>
    /// 判斷字串內是否全是中文
    /// </summary>
    public interface ICheckIsChinese
    {
        /// <summary>
        /// 透過「將字元先轉換為Unicode再轉換為32位元帶正負號的整數」來判斷字串內是否全是中文
        /// </summary>
        /// <param name="sText">要判斷的字串</param>
        /// <returns>true/false</returns>
        public bool fnCheckIsChinese(string sText);
    }
}
