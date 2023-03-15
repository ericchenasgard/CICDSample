namespace Net_Core_Common_Services.Public.CheckIsChinese
{
    /// <summary>
    /// 判斷字串內是否全是中文
    /// </summary>
    public class CCheckIsChinese : ICheckIsChinese
    {
        /// <summary>
        /// 透過「將字元先轉換為Unicode再轉換為32位元帶正負號的整數」來判斷字串內是否全是中文
        /// </summary>
        /// <param name="sText">要判斷的字串</param>
        /// <returns>true/false</returns>
        public bool fnCheckIsChinese(string sText)
        {
            // 回傳結果
            bool bIsChinese = false;

            // 目前字元的整數
            int iCurrent = 0;

            // Unicode中文字元中，最大整數
            int iMax = Convert.ToInt32("9fff", 16);

            // Unicode中文字元中，最小整數
            int iMin = Convert.ToInt32("4e00", 16);

            // 將字串拆開
            for (int i = 0; i < sText.Length; i++)
            {
                // 取得目前字元的整數
                iCurrent = Convert.ToInt32(Convert.ToChar(sText.Substring(i, 1)));

                // 檢查目前字元是否屬於Unicode中文字元範圍內
                if (iCurrent >= iMin && iCurrent < iMax)
                {
                    bIsChinese = true;
                }
                else
                {
                    bIsChinese = false;
                    break;
                }
            }

            return bIsChinese;
        }
    }
}
