using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Message
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class MessageAttribute : Attribute
    {
        /// <summary>
        /// 附加在属性上
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="description">状态描述</param>
        /// <param name="allowOverride">是否允许被全局设置覆盖</param>
        public MessageAttribute(int code, string description, bool allowOverride = false)
        {
            AllowOverride = allowOverride;
            Detail = new MessageInfo
            {
                Code = code,
                Description = description
            };
        }

        /// <summary>
        /// 附加在字段上,状态码自动取字段值
        /// </summary>
        /// <param name="description">状态描述</param>
        /// <param name="allowOverride">是否允许被全局设置覆盖</param>
        public MessageAttribute(string description, bool allowOverride = false)
        {
            //此种情况下,状态码在运行时将被当前字段的值覆盖
            AllowOverride = allowOverride;
            Detail = new MessageInfo
            {
                Code = -99,
                Description = description
            };
        }

        public bool AllowOverride { get; set; }
        public MessageInfo Detail { get; private set; }
    }

}
