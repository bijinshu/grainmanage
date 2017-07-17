using System;

namespace GrainManage.Web.Models.MetaData
{
    public class MetaDataDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string TypeCode { get; set; }
        public string Remark { get; set; }
        public DateTime? Created { get; set; }
    }
}
