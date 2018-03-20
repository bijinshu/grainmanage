using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models
{
    public class WhiteIP
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public int Status { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
