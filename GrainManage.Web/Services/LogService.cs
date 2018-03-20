using DataBase.GrainManage.Models;
using DataBase.GrainManage.Models.Log;
using GrainManage.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Services
{
    public class LogService
    {
        public static int AddActionLog(ActionLog model)
        {
            var db = new GrainManageDB();
            var sql = "insert into log_action(UserId,UserName,Path,ClientIP,Method,Para,Level,StartTime,Status,EndTime,TimeSpan) values(@UserId,@UserName,@Path,@ClientIP,@Method,@Para,@Level,@StartTime,@Status,@EndTime,@TimeSpan);select last_insert_id()";
            return db.ExecuteScalar<int>(sql, model);
        }
        public static void AddExceptionLog(ExceptionLog model)
        {
            var db = new GrainManageDB();
            var sql = "insert into log_exception(Path,Para,Message,StackTrace,ClientIP,CreatedAt) values(@Path,@Para,@Message,@StackTrace,@ClientIP,@CreatedAt)";
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