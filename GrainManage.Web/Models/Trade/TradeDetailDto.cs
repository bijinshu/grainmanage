using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models.Trade
{
    public class TradeDetailDto
    {
        public int Id { get; set; }
        public int TradeId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal RoughWeight { get; set; }
        public decimal Tare { get; set; }
        public decimal ActualMoney { get; set; }
        public string Remark { get; set; }
    }
}
