using System.Threading;
using System.Threading.Tasks;
using bugTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace bugTracker.Core.Persistence
{
    public interface IBugContext
    {
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true,
            CancellationToken cancellationToken = default(CancellationToken));

        DbSet<Bug> Bugs { get; set; }
        DbSet<User> Users { get; set; }
    }
}