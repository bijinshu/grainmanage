
namespace GrainManage.Web.Models.Trade
{
    public class TradeTotalView
    {
        public string Grain { get; set; }
        public string TradeType { get; set; }
        public int Frequency { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalMoney { get; set; }
        public decimal ActualTotalMoney { get; set; }
        public int CreatedBy { get; set; }
    }
}
