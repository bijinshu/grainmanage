using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Log
{
    public class LoginLog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LoginIP { get; set; }
        public string Status { get; set; }
        public int Level { get; set; }
        public int TypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
