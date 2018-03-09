using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models
{
    public class CookieUserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CompId { get; set; }
        public int Level { get; set; }
        public string Token { get; set; }
        public string ExpiredAt { get; set; }
        /// <summary>
        /// 登录终端（0：PC 1:移动端）
        /// </summary>
        public int Agent { get; set; }
    }
}
