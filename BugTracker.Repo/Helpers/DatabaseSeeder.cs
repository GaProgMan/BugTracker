using System;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data.Entities;
using BugTracker.Repo.Data;

namespace BugTracker.Repo.Helpers
{
    public class DatabaseSeeder
    {
        private readonly DataContext _dataContext;

        public DatabaseSeeder(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> SeedBugEntries()
        {
            _dataContext.Bugs.Add(
                new Bug()
                {
                    Title = "Bug Tracker not online",
                    Description = "The Bug Tracker is not online. In the words of Cpt. Picard: 'Make it so'"
                });
            return await _dataContext.SaveChangesAsync();
        }
    }
}