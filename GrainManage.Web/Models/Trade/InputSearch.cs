using System;

namespace GrainManage.Web.Models.Trade
{
    public class InputSearch : Pageable
    {
        public int? TradeType { get; set; }
        public string ProductName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string ContactName { get; set; }
    }
}
