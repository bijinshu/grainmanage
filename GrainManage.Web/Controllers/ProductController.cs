using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.GrainManage.Models.BM;
using Microsoft.AspNetCore.Mvc;

namespace GrainManage.Web.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var repo = GetRepo<Product>();
            var list = repo.GetFiltered(f => f.Status == Status.Enabled).Select(s => new { s.Id, s.Name }).ToList();
            return JsonNet(list);
        }
    }
}