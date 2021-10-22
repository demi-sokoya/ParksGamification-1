using ParksGamification.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;
using Newtonsoft.Json;
using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace ParksGamification.Services
{
    class ParkDataStoreAzureBlobStorageJson : IParkDataStore<Park>
    {
        //Related Documentation:
        //https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet
        //https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-xamarin
        //https://docs.microsoft.com/en-us/visualstudio/data-tools/how-to-save-and-edit-connection-strings?view=vs-2019

        //Required Nuget Packages:
        //Azure.Storage.Blobs
        //Azure.Core

        private readonly BlobServiceClient service = new BlobServiceClient(ConnectionString);

        //Important: Never store connectionstrings in a file you commit to GitHub. Having the connectionstring here is temporary for this example. We will discuss proper key storage in the future.
        private static string ConnectionString => "connectionstringhere";
        private static string Container => "data";
        private static string FileName => "parks.json";

        public ParkDataStoreAzureBlobStorageJson()
        {
        }

        public async Task<IEnumerable<Park>> GetParks()
        {
            var parks = await ReadFile();

            return parks;
        }

        public async Task<Park> GetPark(int parkId)
        {
            var parks = await ReadFile();
            var park = parks.Find(p => p.Id == parkId);
            return park;
        }

        public async Task AddPark(Park park) //****
        {
            var parks = await ReadFile();
            parks.Add(park);

            await WriteFile(parks);
        }

        public async Task UpdatePark(Park park)
        {
            var parks = await ReadFile();
            parks[parks.FindIndex(p => p.Id == park.Id)] = park;

            await WriteFile(parks);
        }

        public async Task WriteFile(List<Park> parks)
        {
            string jsonString = JsonConvert.SerializeObject(parks);

            var stream = new MemoryStream();

            var writer = new StreamWriter(stream);
            writer.Write(jsonString);
            writer.Flush();
            stream.Position = 0;

            BlobClient blob = service.GetBlobContainerClient(Container).GetBlobClient(FileName);

            await blob.UploadAsync(stream);
        }

        public async Task<List<Park>> ReadFile()
        {
            BlobClient blob = service.GetBlobContainerClient(Container).GetBlobClient(FileName);

            if (blob.Exists())
            {
                var stream = new MemoryStream();
                await blob.DownloadToAsync(stream);

                stream.Position = 0;

                var jsonString = new StreamReader(stream).ReadToEnd();

                var parks = JsonConvert.DeserializeObject<List<Park>>(jsonString);

                return parks;

            }
            else
            {
                var defaultParks = GetDefaultParks();

                await WriteFile(defaultParks);

                return defaultParks;
            }
        }

        public List<Park> GetDefaultParks()
        {
            var parks = new List<Park>() {
                    new Park { Name = "Park A Local Json File", Description = "This is park a." },
                    new Park { Name = "Park B Local Json File", Description = "This is park b." },
                    new Park { Name = "Park C Local Json File", Description = "This is park c." },
                    new Park { Name = "Park D Local Json File", Description = "This is park d." }
                };

            return parks;
        }
    }
}
