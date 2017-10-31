using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Dal
{
    public class CommonDB
    {
        public static List<T> Query<T>(string connectionString, string sql, object parameters = null, string databaseName = null)
        {
            using (var conn = ConnectionFactory.GetOpenConnection(connectionString, databaseName))
            {
                return conn.Query<T>(sql, parameters).ToList();
            }
        }

        public static int Execute(string connectionString, string sql, object parameters = null, string databaseName = null)
        {
            using (var conn = ConnectionFactory.GetOpenConnection(connectionString, databaseName))
            {
                return conn.Execute(sql, parameters);
            }
        }
        public static T ExecuteScalar<T>(string connectionString, string sql, object parameters = null, string databaseName = null)
        {
            using (var conn = ConnectionFactory.GetOpenConnection(connectionString, databaseName))
            {
                CommandDefinition cmd = new CommandDefinition(sql, parameters);
                return conn.ExecuteScalar<T>(cmd);
            }
        }
    }
}
