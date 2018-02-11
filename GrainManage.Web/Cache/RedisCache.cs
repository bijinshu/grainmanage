using GrainManage.Common;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GrainManage.Web.Cache
{
    public class RedisCache : GrainManage.Common.ICache
    {
        private static readonly object lockObj = new object();
        private static IConnectionMultiplexer connectionMultiplexer = null;
        protected static IDatabase GetDbClient(int db)
        {
            return Redis.GetDatabase(db);
        }
        public T Get<T>(string key)
        {
            var client = GetDbClient(Db);
            return Deserialize<T>(client.StringGet(key));
        }
        public void Set<T>(string key, T value, DateTime? expiresAt = null)
        {
            var client = GetDbClient(Db);
            if (expiresAt.HasValue)
            {
                client.StringSet(key, Serialize(value), expiresAt.Value - DateTime.Now);
            }
            else
            {
                client.StringSet(key, Serialize(value));
            }
        }
        public void Enqueue<T>(string listId, T value)
        {
            var client = GetDbClient(Db);
            client.ListLeftPush(listId, Serialize(value));
        }
        public T Dequeue<T>(string listId)
        {
            var client = GetDbClient(Db);
            return Deserialize<T>(client.ListRightPop(listId));
        }
        public void AddToList<T>(string listId, params T[] values)
        {
            var client = GetDbClient(Db);
            foreach (var item in values)
            {
                client.ListRightPush(listId, Serialize(item));
            }
        }
        public List<T> GetAllItemsFromList<T>(string listId)
        {
            var result = new List<T>();
            var client = GetDbClient(Db);
            var list = client.ListRange(listId);
            if (list != null && list.Any())
            {
                result.AddRange(list.Select(s => Deserialize<T>(s)));
            }
            return result;
        }
        public int GetListCount(string listId)
        {
            var client = GetDbClient(Db);
            return (int)client.ListLength(listId);
        }
        public void AddToSet<T>(string setId, T value)
        {
            var client = GetDbClient(Db);
            client.SetAdd(setId, Serialize(value));
        }
        public List<T> GetAllItemsFromSet<T>(string setId)
        {
            var result = new List<T>();
            var client = GetDbClient(Db);
            var set = client.SetMembers(setId);
            if (set != null && set.Any())
            {
                result.AddRange(set.Select(s => Deserialize<T>(s)));
            }
            return result;
        }
        public int GetSetCount(string setId)
        {
            var client = GetDbClient(Db);
            return (int)client.SetLength(setId);

        }
        public void Remove(params string[] keys)
        {
            var client = GetDbClient(Db);
            foreach (var item in keys)
            {
                client.KeyDelete(item);
            }
        }
        public bool ExpireAt(string key, DateTime expiresAt)
        {
            var client = GetDbClient(Db);
            return client.KeyExpire(key, expiresAt);
        }
        public void SaveAsync()
        {
            var client = GetDbClient(Db);
            client.Execute("SAVE");
        }
        public void Increment(string key)
        {
            var client = GetDbClient(Db);
            client.StringIncrement(key);
        }

        private static IConnectionMultiplexer Redis
        {
            get
            {
                if (connectionMultiplexer == null || !connectionMultiplexer.IsConnected)
                {
                    lock (lockObj)
                    {
                        if (connectionMultiplexer == null || !connectionMultiplexer.IsConnected)
                        {
                            connectionMultiplexer = ConnectionMultiplexer.Connect(AppConfig.GetValue("RedisServer"));
                        }
                    }
                }
                return connectionMultiplexer;
            }
        }

        private static string Serialize<T>(T obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(obj);
        }
        private T Deserialize<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
        public int Db { get; set; }
    }
}
