using System;

namespace GrainManage.Web.Models.Trade
{
    public class TradeDetailView
    {
        public int TradeID { get; set; }
        public string ContactName { get; set; }  
        public string Area { get; set; }
        public string Cellphone { get; set; }
        public string Grain { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal ActualMoney { get; set; }
        public string TradeType { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? TradeTime { get; set; }
    }
}
