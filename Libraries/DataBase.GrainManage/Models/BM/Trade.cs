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
        public int ContactId { get; set; }
        public string Grain { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal ActualMoney { get; set; }
        public string TradeType { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public DateTime? Created { get; set; }
        public DateTime Modified { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual User Owner { get; set; }
    }
}
