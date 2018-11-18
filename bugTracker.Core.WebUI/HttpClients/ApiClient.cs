using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using bugTracker.Core.DTO.ViewModels;

namespace bugTracker.Core.WebUI.HttpClients
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<BugViewModel> GetBugDetails(int bugId)
        {
            var result = await _client.GetAsync($"/Bugs/Get/{bugId}");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsAsync<BugViewModel>();
            return response;
        }

        public async Task<List<BugViewModel>> GetBugs()
        {
            var result = await _client.GetAsync("/Bugs/Search");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsAsync<List<BugViewModel>>();
            return response;
        }

        public async Task CreateBug(string bug)
        {
            var result = await _client.PostAsJsonAsync("/Bugs/Create", bug);
            result.EnsureSuccessStatusCode();
        }
    }
}