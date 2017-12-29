using Dapper;
using GrainManage.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace GrainManage.Dal
{
    public abstract class BaseDB
    {
        protected string ConnectionString { get; set; }
        private IDbConnection connection = null;

        public ITransaction BeginTransaction(System.Data.IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
        {
            connection = ConnectionFactory.GetOpenConnection(ConnectionString);
            return new DapperTransaction(connection.BeginTransaction(isolationLevel));
        }

        public int Insert<T>(T value, bool ignore = false)
        {
            var type = typeof(T);
            if (type.IsGenericType && value is IEnumerable)
            {
                type = type.GetGenericArguments()[0];
            }
            else if (type.IsArray)
            {
                type = type.GetElementType();
            }
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(s => s.Name).ToList();
            var sql = string.Format("insert {3} into {0}({1}) values({2})", type.Name, string.Join(",", properties), string.Join(",", properties.Select(s => "@" + s)), ignore ? "ignore" : string.Empty);
            if (connection != null)
            {
                return connection.Execute(sql, value);
            }
            else
            {
                return CommonDB.Execute(ConnectionString, sql, value);
            }
        }

        public List<T> Select<T>(string sql, object parameters = null, string databaseName = null)
        {
            if (connection != null)
            {
                return connection.Query<T>(sql, parameters).ToList();
            }
            else
            {
                return CommonDB.Query<T>(ConnectionString, sql, parameters, databaseName);
            }
        }

        public int Execute(string sql, object parameters = null, string databaseName = null)
        {
            if (connection != null)
            {
                return connection.Execute(sql, parameters);
            }
            else
            {
                return CommonDB.Execute(ConnectionString, sql, parameters, databaseName);
            }
        }
        public T ExecuteScalar<T>(string sql, object parameters = null, string databaseName = null)
        {
            if (connection != null)
            {
                CommandDefinition cmd = new CommandDefinition(sql, parameters);
                var obj = connection.ExecuteScalar(cmd);
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            else
            {
                return CommonDB.ExecuteScalar<T>(ConnectionString, sql, parameters, databaseName);
            }
        }
    }
}
