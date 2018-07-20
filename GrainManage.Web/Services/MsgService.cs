using GrainManage.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Services
{
    public class MsgService
    {
        public static List<string> GetKeywords(int type)
        {
            var db = new GrainManageDB();
            var sql = "select `Key` from weixin_msg where `Status`=1 and `Type`=@type";
            return db.Select<string>(sql, new { type });
        }
    }
}
