using DataBase.GrainManage.Models;
using GrainManage.Web.Models.MetaData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Controllers
{
    public class MetaDataController : BaseController
    {
        public ActionResult GetTradeType()
        {
            return Json(GetNameByType("TradeType"));
        }

        public ActionResult GetPriceType()
        {
            return Json(GetNameByType("TradeType"));
        }

        [HttpPost]
        public ActionResult GetGrainType()
        {
            return Json(GetNameByType("GrainType"));
        }

        private List<string> GetNameByType(string typeCode)
        {
            var repo = GetRepo<MetaData>();
            var list = repo.GetFiltered(f => f.TypeCode == typeCode, false, o => o.Content).Select(s => s.Content).ToList();
            return list;
        }
    }
}
