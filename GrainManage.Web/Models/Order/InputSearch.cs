using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models.Order
{
    public class InputSearch : Pageable
    {
        public string CompName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int? Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
