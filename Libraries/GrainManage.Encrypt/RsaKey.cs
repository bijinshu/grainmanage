using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GrainManage.Encrypt
{
    public class RsaKey
    {
        private static byte[] keyData = null;
        private static byte[] pubKey = null;
        private static object lockObj = new object();
        static RsaKey()
        {
            var text = RSAEncrypt.GeneratePrivateKey();
            keyData = RSAEncrypt.ConvertToBlob(text, true);
            pubKey = RSAEncrypt.ConvertToBlob(text, false);
        }
        /// <summary>
        /// 私钥
        /// </summary>
        public static byte[] PrivateKey { get { return keyData; } }
        /// <summary>
        /// 公钥
        /// </summary>
        public static byte[] PubKey { get { return pubKey; } }
        /// <summary>
        /// 将密钥写入到指定文件（当文件已存在时，不进行任何操作）
        /// </summary>
        /// <param name="path"></param>
        public static void WriteTo(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                var directory = System.IO.Path.GetDirectoryName(path);
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
                System.IO.File.WriteAllBytes(path, PrivateKey);
            }
        }
        /// <summary>
        /// 从指定路径加载密钥文件
        /// </summary>
        /// <param name="path"></param>
        public static void ReadFrom(string path)
        {
            lock (lockObj)
            {
                if (System.IO.File.Exists(path))
                {
                    keyData = System.IO.File.ReadAllBytes(path);
                    var text = RSAEncrypt.ConvertToXml(keyData, false);
                    pubKey = RSAEncrypt.ConvertToBlob(text, false);
                }
            }
        }
    }
}
