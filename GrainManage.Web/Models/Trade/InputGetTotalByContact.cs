using System;

namespace GrainManage.Web.Models.Trade
{
    public class InputGetTotalByContact : InputModel, ITimeRanged
    {
        public string TradeType { get; set; }
        public string Grain { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Area { get; set; }
        public string ContactName { get; set; }
    }
}
