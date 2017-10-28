using System.Security.Cryptography;
using System.Text;

namespace GrainManage.Encrypt
{
    public class AESEncrypt
    {
        private static readonly byte[] defaultKey = null;
        private static readonly byte[] defaultIV = null;
        static AESEncrypt()
        {
            defaultKey = Encoding.UTF8.GetBytes(RandomGenerator.Next(32));
            defaultIV = Encoding.UTF8.GetBytes(@"([^1234567890$])");
        }
        public static string Encrypt(string toEncrypt, string key = "")
        {
            if (string.IsNullOrEmpty(toEncrypt))
            {
                return string.Empty;
            }
            byte[] keyArray = string.IsNullOrEmpty(key) ? defaultKey : Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            using (RijndaelManaged rDel = new RijndaelManaged())
            {
                using (ICryptoTransform cTransform = rDel.CreateEncryptor(keyArray, defaultIV))
                {
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    return FormatConvertor.ToHexString(resultArray);
                }
            }
        }
        public static string Decrypt(string toDecrypt, string key = "")
        {
            if (string.IsNullOrEmpty(toDecrypt))
            {
                return string.Empty;
            }
            byte[] keyArray = string.IsNullOrEmpty(key) ? defaultKey : Encoding.UTF8.GetBytes(key);
            byte[] toDecryptArray = FormatConvertor.FromHexString(toDecrypt);
            using (RijndaelManaged rDel = new RijndaelManaged())
            {
                using (ICryptoTransform cTransform = rDel.CreateDecryptor(keyArray, defaultIV))
                {
                    byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
                    return Encoding.UTF8.GetString(resultArray);
                }
            }
        }
        public static string Key { get { return Encoding.UTF8.GetString(defaultKey); } }
    }
}
