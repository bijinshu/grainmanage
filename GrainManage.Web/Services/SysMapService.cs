using GrainManage.Dal;
using GrainManage.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Services
{
    public class SysMapService
    {
        public static WeiXinMsg Get(string key)
        {
            var db = new GrainManageDB();
            var sql = "select * from weixin_msg where `Key`=@key and `Status`=1";
            return db.Select<WeiXinMsg>(sql, new { key }).FirstOrDefault();
        }
    }
}
