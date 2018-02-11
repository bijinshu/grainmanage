using System;

namespace GrainManage.Web.Models.Contact
{
    public class InputSearch : BaseInput
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
