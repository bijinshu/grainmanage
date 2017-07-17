using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Guid { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public virtual User Owner { get; set; }
    }
}
