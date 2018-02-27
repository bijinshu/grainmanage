using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class PriceInfo
    {
        public int Id { get; set; }
        public int CompId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int PriceType { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public virtual User Owner { get; set; }
    }
}
