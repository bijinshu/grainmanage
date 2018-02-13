using System;

namespace GrainManage.Web.Models.Trade
{
    public class InputGetTotal : BaseInput
    {
        public int? TradeType { get; set; }
        public string Grain { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
