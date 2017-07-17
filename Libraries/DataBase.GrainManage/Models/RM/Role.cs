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
        public bool CheckApi { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

