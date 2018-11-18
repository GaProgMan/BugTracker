using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using bugTracker.Core.Entities;

namespace bugTracker.Core.Persistence.Helpers
{
    public class DatabaseSeeder
    {
        private readonly IBugContext _context;

        public DatabaseSeeder(IBugContext context)
        {
            _context = context;
        }

        public async Task<int> SeedBugEntitiesFromJson(string filePath)
        {
            if (CheckSeedFilePath(filePath))
            {
                var seedData = ParseSeedFileToType<Bug>(filePath);

                _context.Bugs.AddRange(seedData);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> SeedUserEntitiesFromJson(string filePath)
        {
            if (CheckSeedFilePath(filePath))
            {
                var seedData = ParseSeedFileToType<User>(filePath);

                _context.Users.AddRange(seedData);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        private List<T> ParseSeedFileToType<T>(string filePath)
        {
            var dataSet = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(dataSet);
        }

        private bool CheckSeedFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"Value of {filePath} must be supplied to {nameof(SeedBugEntitiesFromJson)}");
            }
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"The file { filePath} does not exist");
            }

            return true;
        }
    }
}