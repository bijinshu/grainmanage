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
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public int CompId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public virtual User Owner { get; set; }
    }
}
