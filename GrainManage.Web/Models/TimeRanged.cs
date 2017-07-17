using System;
namespace GrainManage.Web.Models
{
    public class TimeRanged : ITimeRanged
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
