using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Models.User
{
    public class InputSearch : Pageable
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public int? Status { get; set; }
        public string Mobile { get; set; }
    }
}