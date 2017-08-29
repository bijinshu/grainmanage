using System;

namespace GrainManage.Web.Models.Contact
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string PhotoUrl { get; set; }
    }
}
