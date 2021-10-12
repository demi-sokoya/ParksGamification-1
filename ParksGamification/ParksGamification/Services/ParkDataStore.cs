using ParksGamification.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParksGamification.Services
{
    class ParkDataStore : IParkDataStore<Park>
    {
        private List<Park> parks;
        async Task Init()
        {
            await Task.Delay(100);
        }
        public async Task<IEnumerable<Park>> GetParks()
        {
            await Init();

            parks = new List<Park>
            {
                new Park { Id = 1, Name = "Park A", Description = "This is park a."},
                new Park { Id = 2, Name = "Park B", Description = "This is park b."},
                new Park { Id = 3, Name = "Park C", Description = "This is park c."},
                new Park { Id = 4, Name = "Park D", Description = "This is park d."}
            };

            return parks;
        }

        public async Task<Park> GetPark(int parkId)
        {
            await Init();

            return parks.Find(park => park.Id == parkId);
        }
    }
}
