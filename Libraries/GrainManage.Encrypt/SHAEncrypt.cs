using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Encrypt
{
    public class SHAEncrypt
    {
        public static string SHA1(string text)
        {
            return SHA(text, new SHA1CryptoServiceProvider());
        }

        public static string SHA256(string text)
        {
            return SHA(text, new SHA256CryptoServiceProvider());
        }

        public static string SHA384(string text)
        {
            return SHA(text, new SHA384CryptoServiceProvider());
        }

        public static string SHA512(string text)
        {
            return SHA(text, new SHA512CryptoServiceProvider());
        }

        private static string SHA(string text, HashAlgorithm sha)
        {
            using (sha)
            {
                //将mystr转换成byte[]
                byte[] dataToHash = Encoding.UTF8.GetBytes(text);
                //Hash运算
                byte[] dataHashed = sha.ComputeHash(dataToHash);
                //将运算结果转换成string
                return FormatConvertor.ToHexString(dataHashed);
            }
        }
    }
}
