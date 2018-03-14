using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal TotalMoney { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
