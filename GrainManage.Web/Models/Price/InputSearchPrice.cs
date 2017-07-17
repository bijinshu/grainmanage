using System;

namespace GrainManage.Web.Models.Price
{
    public class InputSearchPrice : InputModel, ITimeRanged
    {
        public DateTime? EndTime { get; set; }
        public string Grain { get; set; }
        public string PriceType { get; set; }
        public DateTime? StartTime { get; set; }
    }
}
