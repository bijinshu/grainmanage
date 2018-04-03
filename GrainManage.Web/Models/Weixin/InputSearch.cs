using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models.Weixin
{
    public class InputSearch : Pageable
    {
        public string Name { get; set; }
        public string ProductName { get; set; }
    }
}
