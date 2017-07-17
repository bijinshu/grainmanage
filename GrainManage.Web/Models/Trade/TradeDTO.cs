using System;

namespace GrainManage.Web.Models.Trade
{
    public class TradeDto
    {
        public int TradeId { get; set; }
        public int ContactId { get; set; }
        public string Grain { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal ActualMoney { get; set; }
        public string TradeType { get; set; }
        public string Remarks { get; set; }
        public string Creator { get; set; }
        public DateTime? Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
