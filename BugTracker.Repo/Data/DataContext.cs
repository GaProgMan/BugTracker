using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data.Entities;
using BugTracker.Repo.Data.Mapping;
using BugTracker.Repo.Extensions;

namespace BugTracker.Repo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bugMap = new BugMap(modelBuilder.Entity<Bug>());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.ApplyAuditInformation();
            
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Bug> Bugs { get; set; }
    }
}