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
        private static ConcurrentDictionary<string, ActionLog> dic = new ConcurrentDictionary<string, ActionLog>();
        public static void Add(string key, ActionLog model)
        {
            dic.TryAdd(key, model);
        }
        public static void Set(string key, string msg)
        {
            dic.TryGetValue(key, out ActionLog model);
            if (model != null)
            {
                model.EndTime = DateTime.Now;
                model.TimeSpan = DateTime.Now - model.StartTime;
                model.Status = msg ?? string.Empty;
            }
        }
        internal async static Task Run()
        {
            await Task.Run(() =>
            {
                var now = DateTime.Now;
                if (dic.Any())
                {
                    var finishedDic = dic.Where(f => f.Value.EndTime.HasValue).ToDictionary(k => k.Key, v => v.Value);
                    var finishedKeyList = new List<string>();
                    foreach (var item in finishedDic)
                    {
                        try
                        {
                            LogService.AddActionLog(item.Value);
                        }
                        finally
                        {
                            finishedKeyList.Add(item.Key);
                        }
                    }
                    foreach (var finishedKey in finishedKeyList)
                    {
                        dic.Remove(finishedKey, out ActionLog model);
                    }
                    var timeOutKeyList = dic.Where(f => !f.Value.EndTime.HasValue && f.Value.StartTime.AddHours(1) < now).Select(s => s.Key);
                    foreach (var timeOutKey in timeOutKeyList)
                    {
                        dic.Remove(timeOutKey, out ActionLog model);
                        if (model != null)
                        {
                            model.EndTime = DateTime.Now;
                            model.TimeSpan = DateTime.Now - model.StartTime;
                            model.Status = "操作中断或者超时";
                            LogService.AddActionLog(model);
                        }
                    }
                }
            });
        }
    }
}
