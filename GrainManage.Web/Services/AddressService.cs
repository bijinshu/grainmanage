using GrainManage.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Services
{
    public class AddressService
    {
        /// <summary>
        /// 获取待监控地址
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUrl()
        {
            var db = new GrainManageDB();
            var sql = "select Url from rm_address where IsWatching=1 and IsValid=1";
            return db.Select<string>(sql);
        }
    }
}
