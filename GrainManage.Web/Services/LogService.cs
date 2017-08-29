using DataBase.GrainManage.Models;
using GrainManage.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Services
{
    public class LogService
    {
        public static int AddActionLog(dynamic model)
        {
            var db = new GrainManageDB();
            var sql = "insert into log_action(UserName,Path,ClientIP,Method,Para,Level,StartTime) values(@UserName,@Path,@ClientIP,@Method,@Para,@Level,@StartTime);select last_insert_id()";
            return db.ExecuteScalar<int>(sql, model);
        }
        public static int UpdateActionLog(dynamic model)
        {
            var db = new GrainManageDB();
            return db.Execute("update log_action set Status=@Status,EndTime=@EndTime,TimeSpan=@TimeSpan where Id=@Id ", model);
        }
        public static void AddExceptionLog(dynamic model)
        {
            var db = new GrainManageDB();
            var sql = "insert into log_exception(Path,InputParameter,Message,StackTrace,ClientIP,CreatedAt) values(@Path,@InputParameter,@Message,@StackTrace,@ClientIP,@CreatedAt)";
            db.Execute(sql, model);
        }
        public static int DeleteExceptionLog(params int[] ids)
        {
            var db = new GrainManageDB();
            var sql = string.Format("delete from log_exception where Id in ({0})", string.Join(",", ids));
            return db.Execute(sql);
        }

        public static int AddLoginLog(LoginLog model)
        {
            var db = new GrainManageDB();
            model.CreatedAt = DateTime.Now;
            var sql = "insert into log_login(UserName,LoginIP,Status,Level,CreatedAt) values(@UserName,@LoginIP,@Status,@Level,@CreatedAt)";
            return db.Execute(sql, model);
        }
    }
}