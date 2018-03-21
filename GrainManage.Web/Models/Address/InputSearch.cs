using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models.Address
{
    public class InputSearch : Pageable
    {
        public string Path { get; set; }
        public string Remark { get; set; }
        public bool? IsWatching { get; set; }
        public bool? IsValid { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
