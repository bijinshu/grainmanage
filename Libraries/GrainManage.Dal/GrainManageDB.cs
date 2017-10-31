using GrainManage.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrainManage.Dal
{
    public class GrainManageDB : BaseDB
    {
        public GrainManageDB()
        {
            ConnectionString = AppConfig.GetConnectionString("DefaultConnection");
        }
    }
}
