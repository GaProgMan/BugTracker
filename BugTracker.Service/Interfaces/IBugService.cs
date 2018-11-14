using System.Collections.Generic;
using BugTracker.Data.Entities;

namespace BugTracker.Service.Interfaces
{
    public interface IBugService
    {
        IEnumerable<Bug> GetBugs();
        Bug GetBug(int id);
        void InsertBug(Bug Bug);
        void UpdateBug(Bug Bug);
        void DeleteBug(int id);
    }
}