using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GrainManage.Encrypt
{
    public class RSAEncrypt
    {
        public static void CreateKeyFile(string path, bool saveAsText)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                if (saveAsText)
                {
                    string xmlString = RSA.ToXmlString(true);
                    File.WriteAllText(path, xmlString);
                }
                else
                {
                    byte[] blob = RSA.ExportCspBlob(true);
                    File.WriteAllBytes(path, blob);
                }
            }
        }
        /// <summary>
        /// 生成私钥
        /// </summary>
        /// <returns></returns>
        public static string GeneratePrivateKey()
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                string xml = RSA.ToXmlString(true);
                return xml;
            }
        }
        /// <summary>
        /// 导出公钥
        /// </summary>
        /// <param name="xmlString">xml字符串</param>
        /// <returns></returns>
        public static string ExtractPublicKey(string xmlString)
        {
            string publicKey = string.Empty;
            if (!string.IsNullOrEmpty(xmlString))
            {
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.FromXmlString(xmlString);
                    publicKey = RSA.ToXmlString(false);
                }
            }
            return publicKey;
        }
        /// <summary>
        /// 导出公钥
        /// </summary>
        /// <param name="keyBlob">二进制数组</param>
        /// <returns></returns>
        public static string ExtractPublicKey(byte[] keyBlob)
        {
            string publicKey = string.Empty;
            if (keyBlob != null && keyBlob.Length > 0)
            {
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportCspBlob(keyBlob);
                    publicKey = RSA.ToXmlString(false);
                }
            }
            return publicKey;
        }
        /// <summary>
        /// 将xml密钥转换成二进制数组
        /// </summary>
        /// <param name="xmlString">xml字符串</param>
        /// <param name="includePrivateKey">是否包含私钥信息</param>
        /// <returns></returns>
        public static byte[] ConvertToBlob(string xmlString, bool includePrivateKey)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(xmlString);
                byte[] blob = RSA.ExportCspBlob(includePrivateKey);
                return blob;
            }
        }
        /// <summary>
        /// 将二进制数组密钥转换成xml字符串密钥
        /// </summary>
        /// <param name="keyBlob"></param>
        /// <param name="includePrivateKey"></param>
        /// <returns></returns>
        public static string ConvertToXml(byte[] keyBlob, bool includePrivateKey)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportCspBlob(keyBlob);
                string xml = RSA.ToXmlString(includePrivateKey);
                return xml;
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="hexCode">加密后数据</param>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public static string Decrypt(string hexCode, string privateKey)
        {
            byte[] encryptedData = FormatConvertor.FromHexString(hexCode);
            var keyData = ConvertToBlob(privateKey, true);
            var data = Decrypt(encryptedData, keyData);
            return Encoding.UTF8.GetString(data);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="hexCode">加密后数据</param>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public static string Decrypt(string hexCode, byte[] privateKey)
        {
            byte[] encryptedData = FormatConvertor.FromHexString(hexCode);
            var data = Decrypt(encryptedData, privateKey);
            return Encoding.UTF8.GetString(data);
        }
        private static byte[] Decrypt(byte[] encryptedData, byte[] privateKey)
        {
            if (privateKey == null || privateKey.Length == 0)
            {
                return encryptedData;
            }
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportCspBlob(privateKey);
                int maxBlockSize = RSA.KeySize / 8;
                if (encryptedData.Length <= maxBlockSize)
                {
                    byte[] decryptedData = RSA.Decrypt(encryptedData, false);
                    return decryptedData;
                }
                using (var inputStream = new MemoryStream(encryptedData))
                {
                    using (var outputStream = new MemoryStream())
                    {
                        var buffer = new byte[maxBlockSize];
                        int blockSize = inputStream.Read(buffer, 0, maxBlockSize);
                        while (blockSize > 0)
                        {
                            var toDecrypt = new byte[blockSize];
                            System.Array.Copy(buffer, 0, toDecrypt, 0, blockSize);
                            var dectyptedData = RSA.Decrypt(toDecrypt, false);
                            outputStream.Write(dectyptedData, 0, dectyptedData.Length);
                            blockSize = inputStream.Read(buffer, 0, maxBlockSize);
                        }
                        return outputStream.ToArray();
                    }
                }
            }
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="toEncryptString">待加密字符串</param>
        /// <param name="publicKey">公钥</param>
        /// <returns></returns>
        public static string Encrypt(string toEncryptString, string publicKey)
        {
            var dataToEncrypt = Encoding.UTF8.GetBytes(toEncryptString);
            var keyData = ConvertToBlob(publicKey, false);
            var data = Encrypt(dataToEncrypt, keyData);
            return FormatConvertor.ToHexString(data);
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="toEncryptString">待加密字符串</param>
        /// <param name="publicKey">公钥</param>
        /// <returns></returns>
        public static string Encrypt(string toEncryptString, byte[] publicKey)
        {
            var dataToEncrypt = Encoding.UTF8.GetBytes(toEncryptString);
            var data = Encrypt(dataToEncrypt, publicKey);
            return FormatConvertor.ToHexString(data);
        }
        private static byte[] Encrypt(byte[] dataToEncrypt, byte[] publicKey)
        {
            if (publicKey == null || publicKey.Length == 0)
            {
                return dataToEncrypt;
            }
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportCspBlob(publicKey);
                int maxBlockSize = RSA.KeySize / 8 - 11;
                if (dataToEncrypt.Length <= maxBlockSize)
                {
                    byte[] encryptedData = RSA.Encrypt(dataToEncrypt, false);
                    return encryptedData;
                }
                using (var inputStream = new MemoryStream(dataToEncrypt))
                {
                    using (var outputStream = new MemoryStream())
                    {
                        var buffer = new byte[maxBlockSize];
                        int blockSize = inputStream.Read(buffer, 0, maxBlockSize);
                        while (blockSize > 0)
                        {
                            var toEncrypt = new byte[blockSize];
                            System.Array.Copy(buffer, 0, toEncrypt, 0, blockSize);
                            var enctyptedData = RSA.Encrypt(toEncrypt, false);
                            outputStream.Write(enctyptedData, 0, enctyptedData.Length);
                            blockSize = inputStream.Read(buffer, 0, maxBlockSize);
                        }
                        return outputStream.ToArray();
                    }
                }
            }
        }

        public static RSAParameters GetRsaParameters(string xmlString, bool includePrivateParameters = false)
        {
            RSAParameters para = new RSAParameters();
            if (!string.IsNullOrEmpty(xmlString))
            {
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.FromXmlString(xmlString);
                    para = RSA.ExportParameters(includePrivateParameters);
                }
            }
            return para;
        }
    }
}
