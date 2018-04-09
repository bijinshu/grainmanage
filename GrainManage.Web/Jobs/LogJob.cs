using DataBase.GrainManage.Models.Log;
using GrainManage.Web.Services;
using Quartz;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Jobs
{
    [DisallowConcurrentExecution]
    public class LogJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await LogCache.Run();
        }
    }
    public class LogCache
    {
        private static readonly Dictionary<string, ActionLog> dic = new Dictionary<string, ActionLog>();
        public static void Add(string key, ActionLog model)
        {
            dic[key] = model;
        }
        public static void Set(string key, string msg)
        {
            if (dic.ContainsKey(key))
            {
                var model = dic[key];
                if (model != null)
                {
                    model.EndTime = DateTime.Now;
                    model.TimeSpan = DateTime.Now - model.StartTime;
                    model.Status = msg ?? string.Empty;
                }
            }
        }
        internal async static Task Run()
        {
            await Task.Run(() =>
            {
                if (dic.Any())
                {
                    var finishedDic = dic.Where(f => f.Value.EndTime.HasValue).ToDictionary(k => k.Key, v => v.Value);
                    foreach (var item in finishedDic)
                    {
                        try
                        {
                            LogService.AddActionLog(item.Value);
                        }
                        finally
                        {
                            dic.Remove(item.Key);
                        }
                    }
                }
            });
        }
    }
}
