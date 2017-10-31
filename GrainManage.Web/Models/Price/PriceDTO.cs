using System;

namespace GrainManage.Web.Models.Price
{
    public class PriceDto
    {
        public int PriceId { get; set; }
        public string Grain { get; set; }
        public decimal UnitPrice { get; set; }
        public string PriceType { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
