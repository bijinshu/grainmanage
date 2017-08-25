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
        void Enqueue<T>(string listId, T value);
        T Dequeue<T>(string listId);
        void AddToList<T>(string listId, params T[] values);
        List<T> GetAllItemsFromList<T>(string listId);
        int GetListCount(string listId);
        void AddToSet<T>(string setId, T value);
        List<T> GetAllItemsFromSet<T>(string setId);
        int GetSetCount(string setId);
        void Remove(params string[] keys);
        bool ExpireAt(string key, DateTime expiresAt);
        void SaveAsync();
        void Increment(string key);
    }
}
