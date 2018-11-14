using System.Linq;
using BugTracker.Repo.Data;
using BugTracker.Repo.Helpers;

namespace BugTracker.Repo.Extentions
{
    public static class DbContextExtensions
    {
        public static int EnsureSeedData(this DataContext appContext)
        {
            var bookCount = default(int);

            var dbSeeder = new DatabaseSeeder(appContext);

            if (!appContext.Bugs.Any())
            {
                // we want to do this synchronously, as later seed methods
                // (if we implement any) may need our bugs to be in the database
                // before we call them
                bookCount = dbSeeder.SeedBugEntries().Result;
            }

            return bookCount;
        }
    }
}