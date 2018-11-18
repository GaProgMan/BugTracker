using System.IO;
using System.Linq;
using bugTracker.Core.Persistence.Helpers;

namespace bugTracker.Core.Persistence
{
    public static class BugContextExtensions
    {
        public static int EnsureSeedData(this BugContext context)
        {
            var bugCount = default(int);
            var userCount = default(int);

            // Because each of the following seed method needs to do a save
            // (the data they're importing is relational), we need to call
            // SaveAsync within each method.
            // So let's keep tabs on the counts as they come back

            var dbSeeder = new DatabaseSeeder(context);
            if (!context.Users.Any())
            {
                var pathToSeedData = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "UserSeedData.json");
                userCount = dbSeeder.SeedUserEntitiesFromJson(pathToSeedData).Result;
            }

            // Because the Bug seed data _could_ contain Assigned Users, we need to ensure that the bugs
            // are seeded _after_ the users
            if (!context.Bugs.Any())
            {
                var pathToSeedData = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "BugSeedData.json");
                bugCount = dbSeeder.SeedBugEntitiesFromJson(pathToSeedData).Result;
            }

            return bugCount + userCount;
        }
    }
}