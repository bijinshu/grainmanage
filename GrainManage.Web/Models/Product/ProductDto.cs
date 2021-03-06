﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompId { get; set; }
        public string CompName { get; set; }
        public decimal Price { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public int Source { get; set; }
        public bool HasPrivateProduct { get; set; }
        public bool CanModify { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string Creator { get; set; }
    }
}
