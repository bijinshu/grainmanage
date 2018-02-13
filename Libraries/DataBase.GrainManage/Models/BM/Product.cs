using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models.BM
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int ModifiedBy { get; set; }
    }
}
