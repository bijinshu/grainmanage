using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DataBase.GrainManage.Models
{
    //rm_roles
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Auths { get; set; }
        public int Level { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

