using System;
namespace GrainManage.Web.Models.Trade
{
    public class InputGetTotalByArea : InputModel, ITimeRanged
    {
        public string TradeType { get; set; }
        public string Grain { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Area { get; set; }
    }
}
