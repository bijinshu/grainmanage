using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models
{
    public class Address
    {
        public string Url { get; set; }
        /// <summary>
        /// 0:不监控 1:监控 
        /// </summary>
        public bool IsWatching { get; set; }
        /// <summary>
        /// 0:无效地址 1:有效地址
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 0:一般地址 1:公共地址
        /// </summary>
        public int TypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
