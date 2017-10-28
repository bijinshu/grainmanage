using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GrainManage.Message
{
    public class CacheMessage
    {
        private static readonly object syncObj = new object();
        private static readonly Dictionary<string, Dictionary<string, MessageInfo>> messDic = new Dictionary<string, Dictionary<string, MessageInfo>>();
        public static MessageInfo Get<T>(Expression<Func<T, int>> selector)
        {
            var type = typeof(T);
            if (!messDic.Keys.Contains(type.Name))
            {
                lock (syncObj)
                {
                    if (!messDic.Keys.Contains(type.Name))
                    {
                        messDic[type.Name] = MessageManager.GetConfig(type, false);
                    }
                }
            }
            var dic = messDic[type.Name];
            var key = MessageManager.GetKey(selector, false);
            if (dic.ContainsKey(key))
            {
                return dic[key];
            }
            return null;
        }
    }
}
