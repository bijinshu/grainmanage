using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public int Status { get; set; } //0:未激活 1:启用 2:禁用
        public string RealName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public string EncryptKey { get; set; }
        public int ResetCount { get; set; }
        public string Remark { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastActive { get; set; }
    }
}
