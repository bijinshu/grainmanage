using System;

namespace GrainManage.Web.Models.Image
{
    public class ImageDto
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string Guid { get; set; }
        public byte[] File { get; set; }
        public string Remark { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
