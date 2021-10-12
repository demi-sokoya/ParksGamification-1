using ParksGamification.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParksGamification.Services
{
    public interface IParkDataStore<T>
    {
        Task<IEnumerable<Park>> GetParks();
        Task<Park> GetPark(int parkId);
    }
}
