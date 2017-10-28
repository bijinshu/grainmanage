//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;
//using System.Data.Entity.Infrastructure.Interception;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace GrainManage.Core
//{
//    public enum OperationFlags { Scalar = 1, NonQuery = 2, Reader = 4, All = 7 }

//    public class EFIntercepterLogging : DbCommandInterceptor
//    {
//        #region 私有资源
//        private readonly Stopwatch _stopwatch = new Stopwatch();
//        private int count = 0;
//        #endregion
//        public Action<string> RecordAction { get; set; }
//        public OperationFlags OperationFlag { get; set; }
//        public override void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
//        {
//            base.ScalarExecuting(command, interceptionContext);
//            _stopwatch.Restart();
//        }
//        public override void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
//        {
//            _stopwatch.Stop();
//            TraceCommand(command, interceptionContext, OperationFlags.Scalar);
//            base.ScalarExecuted(command, interceptionContext);
//        }
//        public override void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
//        {
//            base.NonQueryExecuting(command, interceptionContext);
//            _stopwatch.Restart();
//        }
//        public override void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
//        {
//            _stopwatch.Stop();
//            TraceCommand(command, interceptionContext, OperationFlags.NonQuery);
//            base.NonQueryExecuted(command, interceptionContext);
//        }
//        public override void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
//        {
//            base.ReaderExecuting(command, interceptionContext);
//            _stopwatch.Restart();
//        }
//        public override void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
//        {
//            _stopwatch.Stop();
//            TraceCommand(command, interceptionContext, OperationFlags.Reader);
//            base.ReaderExecuted(command, interceptionContext);
//        }
//        private void TraceCommand<T>(System.Data.Common.DbCommand command, DbCommandInterceptionContext<T> interceptionContext, OperationFlags operation)
//        {
//            var cmd = command.CommandText;
//            if (command.Parameters != null && command.Parameters.Count > 0)
//            {
//                var paraValues = new object[command.Parameters.Count];
//                for (int i = 0; i < command.Parameters.Count; i++)
//                {
//                    DbParameter item = command.Parameters[i];
//                    if (item.DbType == DbType.String || item.DbType == DbType.Guid)
//                    {
//                        cmd = Replace(cmd, item.ParameterName, "'{" + i + "}'");
//                        if (item.Value != null && item.Value != DBNull.Value)
//                        {
//                            var str = item.Value.ToString().Replace(@"\", @"\\");
//                            paraValues[i] = str.Replace("'", @"\'");
//                        }
//                        else { paraValues[i] = item.Value; }
//                    }
//                    else if (item.DbType == DbType.DateTime || item.DbType == DbType.DateTime2)
//                    {
//                        cmd = Replace(cmd, item.ParameterName, "'{" + i + "}'");
//                        if (item.Value != null && item.Value != DBNull.Value)
//                        {
//                            var value = Convert.ToDateTime(item.Value);
//                            if (value != DateTime.MinValue)
//                            {
//                                paraValues[i] = value.ToString("yyyy-MM-dd HH:mm:ss:fff");
//                                continue;
//                            }
//                        }
//                        paraValues[i] = item.Value;
//                    }
//                    else if (item.DbType == DbType.Boolean)
//                    {
//                        cmd = Replace(cmd, item.ParameterName, "{" + i + "}");
//                        paraValues[i] = Convert.ToInt32(item.Value);
//                    }
//                    else
//                    {
//                        cmd = Replace(cmd, item.ParameterName, "{" + i + "}");
//                        paraValues[i] = item.Value;
//                    }
//                }
//                cmd = string.Format(cmd, paraValues);
//            }
//            var contextName = string.Join(",", interceptionContext.DbContexts.Select(s => s.GetType().Name));
//            var dataBase = string.Join(",", interceptionContext.DbContexts.Select(s => string.Format("{0}={1}", s.Database.Connection.DataSource, s.Database.Connection.Database)).Distinct());

//            if (interceptionContext.Exception != null)
//            {
//                var txtTitle = string.Format("\r\n#*************************************【{0}】执行第【{1}】句时发生异常*************************************", contextName, ++count);
//                var txtResult = string.Format("\r\n 异常信息:{0} \r\n{1}\r\n执行耗时：【{2}】毫秒，数据库【{3}】", interceptionContext.Exception.Message, cmd, _stopwatch.ElapsedMilliseconds, dataBase);
//                Trace.TraceError(txtTitle);
//                Trace.TraceError(txtResult);
//                Record(txtTitle, txtResult, operation);
//            }
//            else
//            {
//                var txtTitle = string.Format("\r\n#*************************************【{0}】成功执行了第【{1}】句*************************************", contextName, ++count);
//                var txtResult = string.Format("\r\n{0}\r\n执行耗时：【{1}】毫秒，数据库【{2}】", cmd, _stopwatch.ElapsedMilliseconds, dataBase);
//                Trace.TraceInformation(txtTitle);
//                Trace.TraceInformation(txtResult);
//                Record(txtTitle, txtResult, operation);
//            }
//        }
//        private void Record(string cmdTitle, string cmdBody, OperationFlags operation)
//        {
//            if (RecordAction != null)
//            {
//                if (operation == (operation & OperationFlag))
//                {
//                    RecordAction(cmdTitle);
//                    RecordAction(cmdBody);
//                }
//            }
//        }
//        private static string Replace(string input, string parameterName, string replacement)
//        {
//            var pattern = string.Format(@"(?<=\W)(?<tag>{0})(?=\b)", parameterName);
//            return Regex.Replace(input, pattern, replacement);
//        }
//    }
//}
