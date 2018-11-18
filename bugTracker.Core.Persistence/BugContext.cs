using System.Threading;
using System.Threading.Tasks;
using bugTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace bugTracker.Core.Persistence
{
    public class BugContext : DbContext, IBugContext
    {
        public BugContext(DbContextOptions<BugContext> options) : base(options) { }
        public BugContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddPrimaryKeys();
        }

        /// <summary>
        /// Asynchronously saves all changes made in the BugContext to the database.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">
        ///     Indicates whether <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AcceptAllChanges" /> is called after the changes have
        ///     been sent successfully to the database.
        /// </param>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        ///     A task that represents the asynchronous save operation. The task result contains the
        ///     number of state entries written to the database.
        /// </returns>
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.ApplyAuditInformation();
            
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}