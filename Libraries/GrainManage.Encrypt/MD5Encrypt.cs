﻿using System.Security.Cryptography;
using System.Text;

namespace GrainManage.Encrypt
{
    public class MD5Encrypt
    {
        public static string Encrypt(string text)
        {

            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] inputData = Encoding.UTF8.GetBytes(text);
                byte[] outputData = md5.ComputeHash(inputData);
                string result = FormatConvertor.ToHexString(outputData);
                return result;
            }
        }
        public static string Encrypt(System.IO.Stream inputStream)
        {

            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] outputData = md5.ComputeHash(inputStream);
                string result = FormatConvertor.ToHexString(outputData);
                return result;
            }
        }
    }
}
