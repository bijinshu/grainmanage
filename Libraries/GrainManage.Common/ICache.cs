using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Common
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, DateTime? expiresAt = null);
        List<string> GetAllKeys();
        bool ExpireAt(string key, DateTime expiresAt);
        void Remove(params string[] keys);
        void RemoveAll();
        void SaveAsync();
        TimeSpan? GetTimeToLive(string key);
    }
}
