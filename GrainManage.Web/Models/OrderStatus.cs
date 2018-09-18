using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models
{
    public class OrderStatus
    {
        /// <summary>
        /// 待发送
        /// </summary>
        public const int WaittingForSend = 0;
        /// <summary>
        /// 待接单
        /// </summary>
        public const int WaittingForReceive = 1;
        /// <summary>
        /// 已接单
        /// </summary>
        public const int Received = 2;
        /// <summary>
        /// 交易成功
        /// </summary>
        public const int Success = 3;
        /// <summary>
        /// 已取消
        /// </summary>
        public const int Canceled = 4;
        /// <summary>
        /// 拒绝接单
        /// </summary>
        public const int Refused = 5;
    }
}
