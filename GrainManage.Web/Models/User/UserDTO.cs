using System;
using System.Collections.Generic;

namespace GrainManage.Web.Models.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public string RealName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public List<int> Roles { get; set; }
        public string RoleNames { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
