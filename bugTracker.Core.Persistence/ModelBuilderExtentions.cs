using bugTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace bugTracker.Core.Persistence
{
    public static class ModelBuilderExtentions
    {
        /// <summary>
        /// Used to create the the primary keys for bugTracker.Core's database model
        /// </summary>
        /// <param name="builder">An instance of the <see cref="ModelBuilder"/> to act on</param>
        public static void AddPrimaryKeys(this ModelBuilder builder)
        {
            builder.Entity<Bug>().ToTable("bugs")
                .HasKey(b => b.Id);

            builder.Entity<User>().ToTable("users")
                .HasKey(u => u.Id);
        }
    }
}