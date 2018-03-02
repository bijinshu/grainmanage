using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Models
{
    public class Tree
    {
        public dynamic id { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public bool asTop { get; set; }
        public bool expanded { get; set; }
        public dynamic parentId { get; set; }
        public List<Tree> children { get; set; }
    }
}