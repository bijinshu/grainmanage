using System;

namespace GrainManage.Web.Models
{
    public interface ITimeRanged
    {
        DateTime? StartTime { get; set; }
        DateTime? EndTime { get; set; }
    }
}
