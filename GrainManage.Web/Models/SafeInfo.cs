using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Web.Models
{
    public class SafeInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 访问令牌
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// AES密钥
        /// </summary>
        public string AESKey { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpiredAt { get; set; }
        /// <summary>
        /// 是否加密输出结果
        /// </summary>
        public bool EncryptOutput { get; set; }
        /// <summary>
        /// 请求IP
        /// </summary>
        public string LoginIP { get; set; }
    }
}
