using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DataBase.GrainManage.Models
{
    //rm_user_roles
    public class UserRole
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public User Account { get; set; }
        public Role Role { get; set; }
    }
}

