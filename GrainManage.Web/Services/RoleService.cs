using GrainManage.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Services
{
    public class RoleService
    {
        public static int GetMaxLevel(IEnumerable<int> roleIds)
        {
            if (roleIds == null || !roleIds.Any())
            {
                return 0;
            }
            var db = new GrainManageDB();
            return db.ExecuteScalar<int>(string.Format("select max(`Level`) from rm_role where Id in({0})", string.Join(",", roleIds)));
        }
    }
}