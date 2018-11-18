using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bugTracker.Core.WebUI.HttpClients;

namespace bugTracker.Core.WebUI.Controllers
{
    public class BugController : Controller
    {
        private readonly IApiClient _apiClient;
        public BugController(IApiClient apiClient)
        {
            _apiClient = apiClient;    
        }

        public async Task<IActionResult> Details(int id)
        {
            var bugDetails = await _apiClient.GetBugDetails(id);
            return View(bugDetails);
        }

        public async Task<bool> Create(string data)
        {
            // Not working at the moment
            await _apiClient.CreateBug(data);
            return true;
        }
    }
}
