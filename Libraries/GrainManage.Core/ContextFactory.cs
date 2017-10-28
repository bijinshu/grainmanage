using System;
using System.Collections.Generic;
using System.Linq;

namespace GrainManage.Core
{
    public class ContextFactory : IContextFactory
    {
        private readonly Dictionary<int, IUnitOfWorkContext> dic = new Dictionary<int, IUnitOfWorkContext>();
        public IUnitOfWorkContext Get<T>() where T : class
        {
            var assembly = typeof(T).Assembly;
            var key = assembly.GetHashCode();
            if (!dic.Keys.Contains(key))
            {
                var dbContextType = assembly.GetTypes().Single(f => typeof(IUnitOfWorkContext).IsAssignableFrom(f) && f.IsClass && !f.IsAbstract);
                var context = Activator.CreateInstance(dbContextType) as IUnitOfWorkContext;
                dic.Add(key, context);
            }
            return dic[key];
        }

        public void Dispose()
        {
            foreach (var context in dic.Values) { try { context.Dispose(); } catch { } }
            dic.Clear();
        }
    }
}
