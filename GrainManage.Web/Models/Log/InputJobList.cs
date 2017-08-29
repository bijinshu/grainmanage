using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Models.Log
{
    public class InputJobList : Pageable
    {
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}