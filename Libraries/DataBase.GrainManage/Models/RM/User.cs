using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class User
    {
        public int Id { get; set; }
        public int CompId { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; } //0:未激活 1:启用 2:禁用
        public string RealName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public string Remark { get; set; }
        public string Roles { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
