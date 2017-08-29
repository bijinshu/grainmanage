using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Log
{
    public class JobLog
    {
        public JobLog()
        {

        }
        public JobLog(string name)
        {
            JobName = name;
        }
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? TimeSpan { get; set; }
    }
}
