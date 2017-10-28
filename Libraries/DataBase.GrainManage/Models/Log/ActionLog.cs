using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Log
{
    public class ActionLog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Path { get; set; }
        public string ClientIP { get; set; }
        public string Method { get; set; }
        public string Status { get; set; }
        public string Para { get; set; }
        public int Level { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? TimeSpan { get; set; }
    }
}
