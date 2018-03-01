using System;

namespace GrainManage.Web.Models.Price
{
    public class PriceDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int PriceType { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public string Creator { get; set; }
        public bool CanModify { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
