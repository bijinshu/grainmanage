using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CompId { get; set; }
        public string CompName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public decimal TotalMoney { get; set; }
        public decimal ActualMoney { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
