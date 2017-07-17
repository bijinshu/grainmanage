using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models
{
    public class ActionLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ActionName { get; set; }
        public string ClientIP { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? TimeSpan { get; set; }
    }
}
