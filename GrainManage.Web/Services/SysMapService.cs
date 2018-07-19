using GrainManage.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Services
{
    public class SysMapService
    {
        public static string GetValue(string key, int type)
        {
            var db = new GrainManageDB();
            var sql = "select Value from sys_map where `Key`=@key and `Type`=@type limit 1";
            return db.Select<string>(sql, new { key, type }).FirstOrDefault();
        }
    }
}
