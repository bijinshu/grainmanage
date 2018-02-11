using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage.Models.Log
{
    public class ExceptionLog
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Para { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string ClientIP { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
