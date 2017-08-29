using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class Price
    {
        public int Id { get; set; }
        public string Grain { get; set; }
        public decimal UnitPrice { get; set; }
        public string PriceType { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public virtual User Owner { get; set; }
    }
}
