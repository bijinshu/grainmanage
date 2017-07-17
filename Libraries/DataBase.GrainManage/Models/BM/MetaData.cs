using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class MetaData
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string TypeCode { get; set; }
        public string Remark { get; set; }
        public DateTime? Created { get; set; }
    }
}
