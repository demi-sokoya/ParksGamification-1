using ParksGamification.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using System;

namespace ParksGamification.Services
{
    class ParkDataStoreSQLite : IParkDataStore<Park>
    {
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "ParksDB.db3");
            }
        }

        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

        static SQLiteAsyncConnection Database;

        public ParkDataStoreSQLite()
        {
            Database = new SQLiteAsyncConnection(DatabasePath, Flags);
        }

        public async Task<IEnumerable<Park>> GetParks()
        {
            List<Park> parks;

            try
            {
                parks = await Database.Table<Park>().ToListAsync();
            }
            catch (Exception e)
            {
                await Database.CreateTableAsync<Park>();

                await Database.InsertAsync(new Park { Name = "Park A SQLite", Description = "This is park a." });
                await Database.InsertAsync(new Park { Name = "Park B SQLite", Description = "This is park b." });
                await Database.InsertAsync(new Park { Name = "Park C SQLite", Description = "This is park c." });
                await Database.InsertAsync(new Park { Name = "Park D SQLite", Description = "This is park d." });

                parks = await Database.Table<Park>().ToListAsync();
            }

            return parks;
        }

        public async Task<Park> GetPark(int parkId)
        {
            var park = await Database.Table<Park>().Where(p => p.Id == parkId).FirstOrDefaultAsync();
            return park;
        }

        public async Task AddPark(Park park)
        {
            await Database.InsertAsync(park);
        }

        public async Task UpdatePark(Park park)
        {
            if(park.Id != 0)
                await Database.UpdateAsync(park);
        }
    }
}
