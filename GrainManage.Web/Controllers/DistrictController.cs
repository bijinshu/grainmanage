using DataBase.ChinaMap.Models;
using GrainManage.Web.Models.District;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrainManage.Web.Controllers
{
    public class DistrictController : BaseController
    {
        /// <summary>
        /// 获取子级所有地址，并限制最大搜索级数
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public ActionResult GetChildDistrict(int districtId)
        {
            var result = new BaseOutput();
            var list = new List<DistrictDto>();
            var repo = GetRepo<District>();
            var district = repo.Get(districtId);
            if (district == null)
            {
                SetResponse(s => s.NoData, null, result);
            }
            else
            {
                int total = 0;
                FillDownward(ref total, 0, int.MaxValue, 0, list, district);
                result.total = total;
                result.data = list;
                SetResponse(s => s.Success, null, result);
            }
            return JsonNet(result);
        }
        /// <summary>
        /// 获取父级所有地址，并限制最大搜索级数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ActionResult GetUpwardDistrict(int districtId)
        {
            var result = new BaseOutput();
            var list = new List<DistrictDto>();
            var repo = GetRepo<District>();
            var district = repo.Get(districtId);
            if (district == null)
            {
                SetResponse(s => s.NoData, null, result);
            }
            else
            {
                FillUpward(list, district, 0);
                result.total = list.Count;
                result.data = list;
                SetResponse(s => s.Success, null, result);
            }
            return JsonNet(result);
        }

        /// <summary>
        /// 根据Id获取地址信息
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetByID(int districtId)
        {
            var result = new BaseOutput();
            var repo = GetRepo<District>();
            var table = repo.Get(districtId);
            if (table != null)
            {
                result.data = MapTo<DistrictDto>(table);
                SetResponse(s => s.Success, null, result);
            }
            else
            {
                SetResponse(s => s.NoData, null, result);
            }
            return JsonNet(districtId);
        }
        /// <summary>
        /// 根据名称搜索
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Search(InputSearch input)
        {
            var result = new BaseOutput();
            int total = 0;
            var repo = GetRepo<District>();
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, f => f.Name.Contains(input.DistrictName), o => o.Name);
            result.total = total;
            result.data = MapTo<List<DistrictDto>>(list);
            if (list.Any())
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }
        /// <summary>
        /// 根据Id获取父级地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetFatherName(InputGetFather input)
        {
            var result = new BaseOutput();
            var repo = GetRepo<District>();
            var item = repo.Get(input.DistrictID);
            result.data = item != null && item.UpID > 0 ? MapTo<DistrictDto>(item.Owner) : null;
            if (result.data == null)
            {
                SetResponse(s => s.NoData, input, result);
            }
            else
            {
                SetResponse(s => s.Success, input, result);
            }
            return JsonNet(result);
        }
        /// <summary>
        /// 根据Id获取子地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetChildName(InputGetChild input)
        {
            var result = new BaseOutput();
            int total = 0;
            var repo = GetRepo<District>();
            var list = repo.GetPaged(out total, input.PageIndex, input.PageSize, f => f.UpID == input.DistrictID);
            if (list.Any())
            {
                result.data = MapTo<List<DistrictDto>>(list);
                SetResponse(s => s.Success, input, result);
            }
            else
            {
                SetResponse(s => s.NoData, input, result);
            }
            return JsonNet(result);
        }


        private static void FillUpward(List<DistrictDto> list, District d, int level)
        {
            if (level > 0 && d.UpID > 0)
            {
                list.Add(MapTo<DistrictDto>(d.Owner));
                FillUpward(list, d.Owner, --level);
            }
        }
        private static void FillDownward(ref int total, int startIndex, int pageSize, int level, List<DistrictDto> list, District d)
        {
            if (level > 0 && level < 4)
            {
                --level;
                if (d.Children != null && d.Children.Any())
                {
                    foreach (var item in d.Children)
                    {
                        ++total;
                        if (total > startIndex && list.Count < pageSize)
                        {
                            list.Add(MapTo<DistrictDto>(item));
                        }
                        FillDownward(ref total, startIndex, pageSize, level, list, item);
                    }
                }
            }
        }
    }
}
