using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models
{
    public class OrderStatus
    {
        public const int WaittingForSend = 0;
        public const int WaittingForReceive = 1;
        public const int Received = 2;
        public const int Success = 3;
        public const int Canceled = 4;
        public const int Refused = 5;
    }
}
