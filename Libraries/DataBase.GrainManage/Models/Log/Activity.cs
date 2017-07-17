using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string LoginIP { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? Created { get; set; }
    }
}
