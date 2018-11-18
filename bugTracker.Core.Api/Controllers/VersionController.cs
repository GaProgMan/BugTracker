using Microsoft.AspNetCore.Mvc;
using bugTracker.Core.Helpers;

namespace bugTracker.Core.Controllers
{
    [Route("/[controller]")]
    [Produces("text/plain")]
    public class VersionController : BaseController
    {
        /// <summary>
        /// Gets the semver formatted version number for the application
        /// </summary>
        /// <returns>
        /// A string representing the semver formatted version number for the application
        /// </returns>
        [HttpGet]
        public string Get()
        {
            return CommonHelpers.GetVersionNumber();
        }
    }
}