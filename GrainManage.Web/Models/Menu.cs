using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Models
{
    public class Menu
    {
        public string id { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public string url { get; set; }
        public bool selected { get; set; }
        public bool expanded { get; set; }
        public string parent { get; set; }
        public List<Menu> children { get; set; }
    }
}