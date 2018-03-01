using System;

namespace GrainManage.Web.Models.Trade
{
    public class TradeDto
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
        public string Creator { get; set; }
        public bool CanModify { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
