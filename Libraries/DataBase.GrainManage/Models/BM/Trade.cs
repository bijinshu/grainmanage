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
        public decimal  ActualMoney { get; set; }
        public int TradeType { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
