using GrainManage.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Services
{
    public class CompanyService
    {
        public static List<string> GetCompanyNames()
        {
            var db = new GrainManageDB();
            return  db.Select<string>("select Name from bm_company limit 50");
        }
    }
}
