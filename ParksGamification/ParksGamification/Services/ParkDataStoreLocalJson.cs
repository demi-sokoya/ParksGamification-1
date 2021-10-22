using Newtonsoft.Json;
using ParksGamification.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ParksGamification.Services
{
    class ParkDataStoreLocalJson : IParkDataStore<Park>
    {
        public static string FilePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "Parks.json");
            }
        }

        private List<Park> ReadFile()
        {
            File.Delete(FilePath);
            try
            {
                var jsonString = File.ReadAllText(FilePath);

                var parks = JsonConvert.DeserializeObject<List<Park>>(jsonString);

                return parks;
            }
            catch (Exception e)
            {
                var defaultParks = GetDefaultParks();

                WriteFile(defaultParks);

                return defaultParks;
            }
        }

        private List<Park> GetDefaultParks()
        {
            var parks = new List<Park>()
            {
                new Park { Id = 1, Name = "Park A Local Json File", Description = "This is park a." },
                new Park { Id = 2, Name = "Park B Local Json File", Description = "This is park b." },
                new Park { Id = 3, Name = "Park C Local Json File", Description = "This is park c." },
                new Park { Id = 4, Name = "Park D Local Json File", Description = "This is park d." }
            };

            return parks;
        }

        private void WriteFile(List<Park> parks)
        {
            var jsonString = JsonConvert.SerializeObject(parks);

            File.WriteAllText(FilePath, jsonString);
        }

        public async Task<Park> GetPark(int parkId)
        {
            var parks = ReadFile();

            var park = parks.Find(p => p.Id == parkId);

            return park;
        }

        public async Task<IEnumerable<Park>> GetParks()
        {
            var parks = ReadFile();

            return parks;
        }

        public async Task UpdatePark(Park park)
        {
            var parks = ReadFile();
            parks[parks.FindIndex(p => p.Id == park.Id)] = park;

            WriteFile(parks);
        }

        public async Task AddPark(Park park)
        {
            var parks = ReadFile();
            parks.Add(park);

            WriteFile(parks);
        }
    }
}
