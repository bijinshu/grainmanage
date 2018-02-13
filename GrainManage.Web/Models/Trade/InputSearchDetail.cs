using System;

namespace GrainManage.Web.Models.Trade
{
    public class InputSearchDetail : BaseInput
    {
        public int? TradeType { get; set; }
        public string Grain { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Area { get; set; }
        public string ContactName { get; set; }
    }
}
