using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompId { get; set; }
        public string CompName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public List<OrderDetailDto> Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
