//using GrainManage.Common;
//using ServiceStack.Redis;
//using ServiceStack.Text;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GrainManage.Web.Cache
//{
//    public class RedisCache : GrainManage.Common.ICache
//    {
//        private static readonly PooledRedisClientManager manager = null;
//        static RedisCache()
//        {
//            var readPoolSize = AppConfig.GetValue<int>("RedisReadPoolSize");
//            var writePoolSize = AppConfig.GetValue<int>("RedisWritePoolSize");
//            var serverList = AppConfig.GetValue("RedisServer").Split(',');
//            var config = new RedisClientManagerConfig
//            {
//                AutoStart = true,
//                MaxReadPoolSize = readPoolSize > 0 ? readPoolSize : 20,
//                MaxWritePoolSize = writePoolSize > 0 ? writePoolSize : 20,
//            };
//            manager = new PooledRedisClientManager(serverList, null, config);
//        }
//        protected static IRedisClient Redis
//        {
//            get { return manager.GetClient(); }
//        }
//        public T Get<T>(string key)
//        {
//            using (var client = Redis)
//            {
//                return client.Get<T>(key);
//            }
//        }
//        public void Set<T>(string key, T value, DateTime? expiresAt = null)
//        {
//            using (var client = Redis)
//            {
//                if (expiresAt.HasValue)
//                {
//                    client.Set<T>(key, value, expiresAt.Value);
//                }
//                else
//                {
//                    client.Set<T>(key, value);
//                }
//            }
//        }
//        public void Enqueue<T>(string listId, T value)
//        {
//            using (var client = Redis)
//            {
//                client.EnqueueItemOnList(listId, JsonSerializer.SerializeToString<T>(value));
//            }
//        }
//        public T Dequeue<T>(string listId)
//        {
//            using (var client = Redis)
//            {
//                var value = client.DequeueItemFromList(listId);
//                return string.IsNullOrEmpty(value) ? default(T) : JsonSerializer.DeserializeFromString<T>(value);
//            }
//        }
//        public void AddToList<T>(string listId, params T[] values)
//        {
//            using (var client = Redis)
//            {
//                client.AddRangeToList(listId, values.Select(s => JsonSerializer.SerializeToString<T>(s)).ToList());
//            }
//        }
//        public List<T> GetAllItemsFromList<T>(string listId)
//        {
//            var result = new List<T>();
//            using (var client = Redis)
//            {
//                var list = client.GetAllItemsFromList(listId);
//                if (list != null && list.Any())
//                {
//                    result.AddRange(list.Select(s => JsonSerializer.DeserializeFromString<T>(s)));
//                }
//            }
//            return result;
//        }
//        public int GetListCount(string listId)
//        {
//            using (var client = Redis)
//            {
//                return client.GetListCount(listId);
//            }
//        }
//        public void AddToSet<T>(string setId, T value)
//        {
//            using (var client = Redis)
//            {
//                client.AddItemToSet(setId, JsonSerializer.SerializeToString<T>(value));
//            }
//        }
//        public List<T> GetAllItemsFromSet<T>(string setId)
//        {
//            var result = new List<T>();
//            using (var client = Redis)
//            {
//                var set = client.GetAllItemsFromSet(setId);
//                if (set != null && set.Any())
//                {
//                    result.AddRange(set.Select(s => JsonSerializer.DeserializeFromString<T>(s)));
//                }
//            }
//            return result;
//        }
//        public int GetSetCount(string setId)
//        {
//            using (var client = Redis)
//            {
//                return client.GetSetCount(setId);
//            }
//        }
//        public void Remove(params string[] keys)
//        {
//            using (var client = Redis)
//            {
//                client.RemoveAll(keys);
//            }
//        }
//        public bool ExpireAt(string key, DateTime expiresAt)
//        {
//            using (var client = Redis)
//            {
//                return client.ExpireEntryAt(key, expiresAt);
//            }
//        }
//        public void SaveAsync()
//        {
//            using (var client = Redis)
//            {
//                client.SaveAsync();
//            }
//        }
//        public void Increment(string key)
//        {
//            using (var client = Redis)
//            {
//                client.IncrementValue(key);
//            }
//        }
//    }
//}
