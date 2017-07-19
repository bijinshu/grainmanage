using System;

namespace GrainManage.Web.Models.Contact
{
    public class InputSearch : InputModel, ITimeRanged
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
