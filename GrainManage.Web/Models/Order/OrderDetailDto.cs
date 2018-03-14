using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models.Order
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal TotalMoney { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
