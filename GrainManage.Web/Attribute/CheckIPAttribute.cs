using DataBase.GrainManage.Models;
using GrainManage.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GrainManage.Web
{
    public class CheckIPAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var ip = HttpUtil.GetRequestHostAddress(context.HttpContext.Request);
            var ipRepo = context.HttpContext.RequestServices.GetService(typeof(IRepository<WhiteIP>)) as IRepository<WhiteIP>;
            if (ipRepo.GetFiltered(f => f.IP == ip).Any())
            {
                return;
            }
            var mes = GrainManage.Message.CacheMessage.Get<StatusCode>(s => s.IdentityFailed);
            context.Result = new JsonResult(new BaseOutput { code = mes.Code, msg = $"{mes.Description}:{ip}" });
        }
        private static bool IsMatch(string ip, string pattern)
        {
            if (!string.IsNullOrEmpty(pattern))
            {
                if (pattern.Contains("*"))
                {
                    pattern = pattern.Replace(".", @"\.").Replace("*", @"\d+");
                    return Regex.IsMatch(ip, pattern);
                }
                return ip == pattern;
            }
            return false;
        }
    }
}
