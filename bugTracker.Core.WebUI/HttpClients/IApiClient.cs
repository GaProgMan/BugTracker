using System.Collections.Generic;
using System.Threading.Tasks;

using bugTracker.Core.DTO.ViewModels;

namespace bugTracker.Core.WebUI.HttpClients
{
    public interface IApiClient
    {
        Task<List<BugViewModel>> GetBugs();

        Task<BugViewModel> GetBugDetails(int bugId);

        Task CreateBug(string bug);
    }
}