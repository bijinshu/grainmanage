using DataBase.GrainManage.Models;
using GrainManage.Web.Models.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrainManage.Web.Controllers
{
    public class MetaDataController : BaseController
    {
        public ActionResult GetTradeType()
        {
            return JsonNet(GetNameByType("TradeType"));
        }

        public ActionResult GetPriceType()
        {
            return JsonNet(GetNameByType("TradeType"));
        }

        [HttpPost]
        public ActionResult GetGrainType()
        {
            return JsonNet(GetNameByType("GrainType"));
        }

        private List<string> GetNameByType(string typeCode)
        {
            var repo = GetRepo<MetaData>();
            var list = repo.GetFiltered(f => f.TypeCode == typeCode, false, o => o.Content).Select(s => s.Content).ToList();
            return list;
        }
    }
}
