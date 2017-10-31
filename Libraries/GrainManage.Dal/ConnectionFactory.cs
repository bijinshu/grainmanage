using MySql.Data.MySqlClient;
using System.Data;

namespace GrainManage.Dal
{
    sealed class ConnectionFactory
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="databaseName">数据库名称(可以更改为指定的数据库)</param>
        /// <returns></returns>
        public static IDbConnection GetOpenConnection(string connectionString, string databaseName = null)
        {
            var connection = new MySqlConnection(connectionString);
            if (!string.IsNullOrEmpty(databaseName))
            {
                connection.ChangeDatabase(databaseName);
            }
            connection.Open();
            return connection;
        }
    }
}
