using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web
{
    public class BaseOutput
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int total { get; set; }
        public dynamic data { get; set; }
    }
}