using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Common
{
    /// <summary>
    /// Unix时间戳从1970-01-01 00:00:00开始
    /// C#获取的Unix时间戳是10位,以秒为单位
    /// Java获取的Unix时间戳是13位,以毫秒为单位
    /// DateTime.Now.Ticks 是从0000-01-01 12:00:00开始，单位为微妙
    /// </summary>
    public class UnixDateTime
    {
        /// <summary>
        /// 获取Unix时间戳（默认以秒为单位）
        /// </summary>
        /// <param name="dt">待转换本地时间</param>
        /// <param name="secondBased">是否以秒为单位(默认)</param>
        /// <returns></returns>
        public static long GetTimeStamp(DateTime dt, bool secondBased = true)
        {
            TimeSpan ts = dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(secondBased ? ts.TotalSeconds : ts.TotalMilliseconds);
        }
        /// <summary>
        /// 转换Unix时间戳为本地时间
        /// </summary>
        /// <param name="timeStamp">时间戳</param>
        /// <param name="secondBased">是否以秒为单位(默认)</param>
        /// <returns></returns>
        public static DateTime GetDateTime(long timeStamp, bool secondBased = true)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            start = secondBased ? start.AddSeconds(timeStamp) : start.AddMilliseconds(timeStamp);
            return start.ToLocalTime();
        }
    }
}
