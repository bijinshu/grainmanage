using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal PreWeight { get; set; }
        public decimal PreMoney { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal ActualMoney { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
