using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GrainManage.Web.Common
{
    public class ExceptionUtil
    {
        /// <summary>
        /// 获取堆栈上的所有异常信息
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetStackMessage(Exception e)
        {
            var builder = new StringBuilder();
            BuildStackMessage(e, builder);
            return builder.ToString();
        }
        /// <summary>
        /// 获取堆栈里最后一层的异常信息
        /// </summary>
        /// <returns></returns>
        public static string GetInnerestMessage(Exception e)
        {
            if (e.InnerException == null)
            {
                return e.Message;
            }
            else
            {
                return GetInnerestMessage(e.InnerException);
            }
        }
        private static void BuildStackMessage(Exception e, StringBuilder builder)
        {
            builder.AppendLine(e.Message);
            if (e.InnerException != null)
            {
                BuildStackMessage(e.InnerException, builder);
            }
        }
    }
}