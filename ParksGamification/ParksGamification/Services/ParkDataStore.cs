using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ParksGamification.Models;

namespace ParksGamification.Services
{
    class ParkDataStore : IDataStore<Park>
    {
        private List<Park> _parks;
        public ParkDataStore()
        {
            _parks = new List<Park>();

            var park = new Models.Park { Id = 1, Name = "GreenPark", Description = "This is an awesome park." };

            park.Amenities.Add(new Park.Amenity() { Type = Park.Amenity.Types.Swing, Quantity = 1, Description = "Blue swing set for ages 3 to 7." });
            park.Amenities.Add(new Park.Amenity() { Type = Park.Amenity.Types.Swing, Quantity = 1, Description = "Green swing set for ages 3 to 7." });

            _parks.Add(park);
        }
        public async Task<bool> AddItemAsync(Park park) { throw new NotImplementedException(); }

        public async Task<bool> UpdateItemAsync(Park park) { throw new NotImplementedException(); }

        public async Task<bool> DeleteItemAsync(int id) { throw new NotImplementedException(); }

        public async Task<Park> GetItemAsync(int id) { throw new NotImplementedException(); }

        public async Task<IEnumerable<Park>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_parks);
        }
    }
}
