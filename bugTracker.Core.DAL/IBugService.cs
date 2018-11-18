using System.Collections.Generic;
using System.Threading.Tasks;
using bugTracker.Core.Entities;

namespace bugTracker.Core.DAL
{
    public interface IBugService
    {
        // Search and Get
        Bug FindById(int id);
        IEnumerable<Bug> Search(string searchKey);
        
        // Writable actions
        Task<bool> SetAssignedUserForBug (int bugId, int userId);
        Task<int> CreateBug(Bug bugToSave);
        Task<bool> DeleteBug(int bugId);
    }
}