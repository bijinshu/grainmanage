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
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}
