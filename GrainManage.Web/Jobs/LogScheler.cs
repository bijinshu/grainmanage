using DataBase.GrainManage.Models.Log;
using GrainManage.Web.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web
{
    public class LogScheler
    {
        public async static void Start()
        {
            // 创建作业调度池
            var factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            // 创建作业
            var job = JobBuilder.Create<LogJob>()
                .WithIdentity("action_log", "logs")
                .Build();
            // 创建触发器，每2s执行一次
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("action_trigger", "logs")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())
                .Build();
            // 加入到作业调度池中
            await scheduler.ScheduleJob(job, trigger);
            await scheduler.Start();
        }

    }
}
