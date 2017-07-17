using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DataBase.GrainManage.Models
{
    //rm_role_api_rights
    public class RoleResource
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ResourceId { get; set; }
        public DateTime CreateTime { get; set; }
        public Role Role { get; set; }
        public Resource Resource { get; set; }
    }
}

