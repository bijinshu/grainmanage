using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GrainManage.Encrypt
{
    public sealed class DESEncrypt
    {
        //默认加密密钥,当设置的密钥无效时,将使用此默认密钥加解密
        private const string DESKey = "%@*&_{^}";

        public static string GenerateKey()
        {
            using (DES desCrypto = DESCryptoServiceProvider.Create())
            {
                return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
            }
        }

        public static string Encrypt(string sInputString, string sKey = "")
        {
            if (string.IsNullOrEmpty(sInputString))
            {
                return string.Empty;
            }
            using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
            {
                byte[] data = Encoding.UTF8.GetBytes(sInputString);
                byte[] key_iv = GetKeyBytes(sKey);
                DES.Key = key_iv;
                DES.IV = key_iv;
                using (ICryptoTransform desencrypt = DES.CreateEncryptor())
                {
                    byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                    return FormatConvertor.ToHexString(result);
                }
            }
        }

        public static string Decrypt(string sInputString, string sKey = "")
        {
            if (string.IsNullOrEmpty(sInputString))
            {
                return string.Empty;
            }
            byte[] data = FormatConvertor.FromHexString(sInputString);
            using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
            {
                byte[] key_iv = GetKeyBytes(sKey);
                DES.Key = key_iv;
                DES.IV = key_iv;
                using (ICryptoTransform desencrypt = DES.CreateDecryptor())
                {
                    byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.UTF8.GetString(result);
                }
            }
        }

        private static byte[] GetKeyBytes(string sKey)
        {
            List<byte> resultKey = new List<byte>();
            if (string.IsNullOrEmpty(sKey))
            {
                resultKey.AddRange(Encoding.UTF8.GetBytes(DESKey));
            }
            else
            {
                byte[] actualKeyValues = Encoding.UTF8.GetBytes(sKey);
                int actualLength = actualKeyValues.Length;
                int neededKeyLength = 8;
                if (actualLength <= neededKeyLength)
                {
                    byte padValue = Convert.ToByte('a');
                    resultKey.AddRange(actualKeyValues);
                    for (int i = 0; i < neededKeyLength - actualLength; i++)
                    {
                        resultKey.Add(padValue);
                    }
                }
                else
                {
                    for (int i = 0; i < neededKeyLength; i++)
                    {
                        resultKey.Add(actualKeyValues[actualLength - i - 1]);
                    }
                }
            }
            return resultKey.ToArray();
        }
    }
}
