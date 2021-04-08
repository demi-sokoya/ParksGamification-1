using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParksGamification.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T park);
        Task<bool> UpdateItemAsync(T park);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
