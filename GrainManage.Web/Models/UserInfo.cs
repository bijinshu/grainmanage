using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Web.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 访问令牌
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string ExpiredAt { get; set; }
        /// <summary>
        /// 请求IP
        /// </summary>
        public string LoginIP { get; set; }
        public int[] Roles { get; set; }
        public List<string> Auths { get; set; }
        public List<string> Urls { get; set; }
        public int Level { get; set; }
    }
}
