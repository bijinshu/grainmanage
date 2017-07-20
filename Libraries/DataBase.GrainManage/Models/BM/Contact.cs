using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public virtual User Owner { get; set; }
    }
}
