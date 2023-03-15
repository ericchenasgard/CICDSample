using System.Security.Cryptography;
using System.Text;

namespace Net_Core_Common_Services.Public.DoAES
{
    /// <summary>
    /// AES加/解密
    /// </summary>
    public class CDoAES : IDoAES
    {
        #region AES加密
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="sText">記錄內文</param>
        /// <returns>加密結果/錯誤訊息</returns>
        public (string, string) fnDoAESEncrypts(string sText)
        {
            string sKey = "Asgard";
            string sSalt = "dragsA";
            string sRT = "";
            string sErrorMessage = "";

            try
            {
                byte[] aText = Encoding.Default.GetBytes(sText + "AddTextString");
                byte[] aSaltBytes = Encoding.Default.GetBytes(sSalt + "AddSaltString");

                // 密碼加鹽
                Rfc2898DeriveBytes oRfc2898DeriveBytes = new Rfc2898DeriveBytes(sKey, aSaltBytes);
                Aes oAes = Aes.Create();
                oAes.KeySize = 256;
                oAes.BlockSize = 128;
                oAes.Key = oRfc2898DeriveBytes.GetBytes(32);
                oAes.IV = oRfc2898DeriveBytes.GetBytes(16);

                ICryptoTransform oEncrypt = oAes.CreateEncryptor(oAes.Key, oAes.IV);
                using (MemoryStream oMemoryStream = new MemoryStream())
                {
                    using (CryptoStream oCryptoStream = new CryptoStream(oMemoryStream, oEncrypt, CryptoStreamMode.Write))
                    {
                        oCryptoStream.Write(aText, 0, aText.Length);
                        oCryptoStream.FlushFinalBlock();
                        oCryptoStream.Close();

                        byte[] aEncryptBytes = oMemoryStream.ToArray();
                        sRT = Convert.ToBase64String(aEncryptBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                sErrorMessage = ex.ToString();
            }

            return (sRT, sErrorMessage);
        }
        #endregion

        #region AES解密
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="sText">記錄內文</param>
        /// <returns>解密結果/錯誤訊息</returns>
        public (string, string) fnDoAESDecrypts(string sText)
        {
            string sKey = "Asgard";
            string sSalt = "dragsA";
            string sRT = sText;
            string sErrorMessage = "";

            try
            {
                byte[] aText = Convert.FromBase64String(sText);
                byte[] aSaltBytes = Encoding.Default.GetBytes(sSalt + "AddSaltString");

                // 密碼加鹽
                Rfc2898DeriveBytes oRfc2898DeriveBytes = new Rfc2898DeriveBytes(sKey, aSaltBytes);
                Aes oAes = Aes.Create();
                oAes.KeySize = 256;
                oAes.BlockSize = 128;
                oAes.Key = oRfc2898DeriveBytes.GetBytes(32);
                oAes.IV = oRfc2898DeriveBytes.GetBytes(16);

                ICryptoTransform oDecryptor = oAes.CreateDecryptor(oAes.Key, oAes.IV);
                using (MemoryStream oMemoryStream = new MemoryStream())
                {
                    using (CryptoStream oCryptoStream = new CryptoStream(oMemoryStream, oDecryptor, CryptoStreamMode.Write))
                    {
                        oCryptoStream.Write(aText, 0, aText.Length);
                        oCryptoStream.FlushFinalBlock();
                        oCryptoStream.Close();

                        byte[] aDecryptorBytes = oMemoryStream.ToArray();
                        sRT = Encoding.Default.GetString(aDecryptorBytes).Replace("AddTextString", "");
                    }
                }
            }
            catch (Exception ex)
            {
                sErrorMessage = ex.ToString();
            }

            return (sRT, sErrorMessage);
        }
        #endregion
    }
}
