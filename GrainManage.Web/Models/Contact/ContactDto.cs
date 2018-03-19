using System;

namespace GrainManage.Web.Models.Contact
{
    public class ContactDto
    {
        public int Id { get; set; }
        public int CompId { get; set; }
        public string CompName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Weixin { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public bool CanModify { get; set; }
        public int TradeCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImgName { get; set; }
    }
}
