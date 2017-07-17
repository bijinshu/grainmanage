using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace DataBase.GrainManage.Models
{
    //rm_api_resources
    public class Resource
    {
        public int Id { get; set; }
        /// <summary>
        /// 资源描述
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// 资源Uri
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 请求方法
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// 附加备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 更新描述
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 是否是各平台都可调用
        /// </summary>
        public bool IsCommon { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// 是否允许匿名访问（此属性为true时,IsCommon也将为true）
        /// </summary>
        public bool IsAnonymous { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

    }
}

