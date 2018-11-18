using System.Collections.Generic;
using System.Threading.Tasks;
using bugTracker.Core.Entities;

namespace bugTracker.Core.DAL 
{
    public interface IDatabaseService
    {
        bool ClearDatabase();

        int SeedDatabase();

        Task<int> SaveAnyChanges();
    }
}