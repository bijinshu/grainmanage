using GrainManage.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using GrainManage.Core;
using DataBase.GrainManage.Models;
using GrainManage.Web.Models.Log;
using DataBase.GrainManage.Models.Log;

namespace GrainManage.Web.Controllers
{
    public class LogController : BaseController
    {
        /// <summary>
        /// 获取异常列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ActionResult ExceptionList(InputExceptionList input)
        {
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            var filter = ExpressionBuilder.Where<ExceptionLog>(f => true);
            if (!string.IsNullOrEmpty(input.Path))
            {
                filter = filter.And(f => f.Path.Contains(input.Path));
            }
            if (input.StartTime.HasValue)
            {
                filter = filter.And(f => f.CreatedAt >= input.StartTime.Value);
            }
            if (input.EndTime.HasValue)
            {
                input.EndTime = input.EndTime.Value.AddDays(1);
                filter = filter.And(f => f.CreatedAt < input.EndTime.Value);
            }
            var repo = GetRepo<ExceptionLog>();
            var list = repo.GetPaged(out int total, input.PageIndex, input.PageSize, filter);
            result.total = total;
            if (list.Any())
            {
                result.data = list;
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.NoData, result);
            }
            return JsonNet(result);
        }
        public ActionResult ActionList(InputActionList input)
        {
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            var filter = ExpressionBuilder.Where<ActionLog>(f => f.Level <= Level);
            if (!string.IsNullOrEmpty(input.Name))
            {
                filter = filter.And(f => f.UserName.Contains(input.Name));
            }
            if (!string.IsNullOrEmpty(input.Path))
            {
                filter = filter.And(f => f.Path.Contains(input.Path));
            }
            if (input.StartTime.HasValue)
            {
                filter = filter.And(f => f.StartTime >= input.StartTime.Value);
            }
            if (input.EndTime.HasValue)
            {
                input.EndTime = input.EndTime.Value.AddDays(1);
                filter = filter.And(f => f.StartTime < input.EndTime.Value);
            }
            var repo = GetRepo<ActionLog>();
            var list = repo.GetPaged(out int total, input.PageIndex, input.PageSize, filter);
            if (list.Any())
            {
                result.total = total;
                result.data = list;
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.NoData, result);
            }
            return JsonNet(result);
        }
        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ActionResult JobList(InputJobList input)
        {
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            var filter = ExpressionBuilder.Where<JobLog>(f => true);
            if (!string.IsNullOrEmpty(input.Name))
            {
                filter = filter.And(f => f.JobName.Contains(input.Name));
            }
            if (input.StartTime.HasValue)
            {
                filter = filter.And(f => f.StartTime >= input.StartTime.Value);
            }
            if (input.EndTime.HasValue)
            {
                input.EndTime = input.EndTime.Value.AddDays(1);
                filter = filter.And(f => f.StartTime < input.EndTime.Value);
            }
            var repo = GetRepo<JobLog>();
            var list = repo.GetPaged(out int total, input.PageIndex, input.PageSize, filter);
            if (list.Any())
            {
                result.total = total;
                result.data = list;
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.NoData, result);
            }
            return JsonNet(result);
        }
        /// <summary>
        /// 获取登录列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ActionResult LoginList(InputLoginList input)
        {
            if (IsGetRequest)
            {
                return View(CurrentUser);
            }
            var result = new BaseOutput();
            var filter = ExpressionBuilder.Where<LoginLog>(f => f.Level <= Level);
            if (!string.IsNullOrEmpty(input.Name))
            {
                filter = filter.And(f => f.UserName.Contains(input.Name));
            }
            if (input.StartTime.HasValue)
            {
                filter = filter.And(f => f.CreatedAt >= input.StartTime.Value);
            }
            if (input.EndTime.HasValue)
            {
                input.EndTime = input.EndTime.Value.AddDays(1);
                filter = filter.And(f => f.CreatedAt < input.EndTime.Value);
            }
            var repo = GetRepo<LoginLog>();
            var list = repo.GetPaged(out int total, input.PageIndex, input.PageSize, filter);
            if (list.Any())
            {
                result.total = total;
                result.data = list;
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.NoData, result);
            }
            return JsonNet(result);
        }
        public ActionResult DeleteException(int Id)
        {
            var result = new BaseOutput();
            result.data = LogService.DeleteExceptionLog(Id);
            if (result.data > 1)
            {
                SetResponse(s => s.Success, result);
            }
            else
            {
                SetResponse(s => s.DeleteFailed, result);
            }
            return JsonNet(result);
        }
    }
}