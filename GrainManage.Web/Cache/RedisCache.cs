using GrainManage.Common;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Web.Cache
{
    public class RedisCache : GrainManage.Common.ICache
    {
        private static readonly PooledRedisClientManager manager = null;
        static RedisCache()
        {
            var readPoolSize = AppConfig.GetValue<int>("RedisReadPoolSize");
            var writePoolSize = AppConfig.GetValue<int>("RedisWritePoolSize");
            var serverList = AppConfig.GetValue("RedisServer").Split(',');
            var config = new RedisClientManagerConfig
            {
                AutoStart = true,
                MaxReadPoolSize = readPoolSize > 0 ? readPoolSize : 20,
                MaxWritePoolSize = writePoolSize > 0 ? writePoolSize : 20,
            };
            manager = new PooledRedisClientManager(serverList, null, config);
        }
        protected static IRedisClient Redis
        {
            get { return manager.GetClient(); }
        }
        public T Get<T>(string key)
        {
            using (var client = Redis)
            {
                return client.Get<T>(key);
            }
        }
        public void Set<T>(string key, T value, DateTime? expiresAt = null)
        {
            using (var client = Redis)
            {
                if (expiresAt.HasValue)
                {
                    client.Set<T>(key, value, expiresAt.Value);
                }
                else
                {
                    client.Set<T>(key, value);
                }
            }
        }
        public List<string> GetAllKeys()
        {
            using (var client = Redis)
            {
                return client.GetAllKeys();
            }
        }
        public void Remove(params string[] keys)
        {
            using (var client = Redis)
            {
                client.RemoveAll(keys);
            }
        }
        public bool ExpireAt(string key, DateTime expiresAt)
        {
            using (var client = Redis)
            {
                return client.ExpireEntryAt(key, expiresAt);
            }
        }
        public void SaveAsync()
        {
            using (var client = Redis)
            {
                client.SaveAsync();
            }
        }
        public void RemoveAll()
        {
            using (var client = Redis)
            {
                client.FlushDb();
            }
        }
        public TimeSpan? GetTimeToLive(string key)
        {
            using (var client = Redis)
            {
                return client.GetTimeToLive(key);
            }
        }
    }
}
