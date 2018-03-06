using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public int CompId { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal ActualMoney { get; set; }
        public int TradeType { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        //public virtual Contact Contact { get; set; }
        //public virtual User Owner { get; set; }
        //public virtual Product Product { get; set; }
    }
}
