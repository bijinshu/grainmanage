﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models.Product
{
    public class InputSearch : Pageable
    {
        public string CompName { get; set; }
        public string ProductName { get; set; }
        public int? Status { get; set; }
        public int? Source { get; set; }
    }
}
