using System.Linq;
using System.Net;
using System.Threading.Tasks;
using bugTracker.Core.DAL;
using bugTracker.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace bugTracker.Core.Controllers
{
    [Route("/[controller]")]
    [Produces("application/json")]
    public class DatabaseController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IDatabaseService _databaseService;
        
        public DatabaseController(IConfiguration configuration, IDatabaseService databaseService)
        {
            _configuration = configuration;
            _databaseService = databaseService;
        }

        /// <summary>
        /// Used to Seed the Database (using JSON files which are included with the application)
        /// </summary>
        /// <returns>
        /// A <see cref="BaseController.MessageResult"/> with the number of entities which
        /// were added to the database.
        /// </returns>
        [HttpGet("SeedData")]
        public JsonResult SeedData()
        {
            var entitiesAdded = _databaseService.SeedDatabase();

            return MessageResult($"Number of new entities added: {entitiesAdded}");

        }

        /// <summary>
        /// Used to drop all current data from the database and recreate any tables
        /// </summary>
        /// <param name="secret">
        /// A passphrase like secret to ensure that a Drop Data action should take place
        /// </param>
        /// <returns>
        /// A <see cref="BaseController.MessageResult"/>
        /// </returns>
        [HttpDelete("DropData")]
        public JsonResult DropData(string secret = null)
        {
            if (SecretChecker.CheckUserSuppliedSecretValue(secret,
                _configuration["dropDatabaseSecretValue"]))
            {
                return ErrorResponse("Incorrect secret");
            }

            var success = _databaseService.ClearDatabase();

            return MessageResult("Database tabled dropped and recreated", success);
        }
    }
}