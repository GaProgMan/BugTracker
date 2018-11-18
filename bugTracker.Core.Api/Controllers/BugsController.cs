using Microsoft.AspNetCore.Mvc;
using System.Linq;
using bugTracker.Core.DAL;
using bugTracker.Core.DTO.Helpers;
using System.Threading.Tasks;
using bugTracker.Core.DTO.ViewModels;

namespace bugTracker.Core.Controllers
{
    [Route("/[controller]")]
    [Produces("application/json")]
    public class BugsController : BaseController
    {
        private readonly IBugService _bugService;

        public BugsController(IBugService bugService)
        {
            _bugService = bugService;
        }


        /// <summary>
        /// Used to get a Bug by its Id
        /// </summary>
        /// <param name="id">The ID of a bug to return</param>
        /// <returns>
        /// If a bug can be found, then a <see cref="BaseController.SingleResult"/>
        /// is returned, which contains a <see cref="bugTracker.Core.DTO.ViewModels.BugViewModel"/>.
        /// If no record can be found, then an <see cref="BaseController.ErrorResponse"/> is returned
        /// </returns>
        [HttpGet("Get/{id}")]
        public JsonResult GetById(int id)
        {
            var bug = _bugService.FindById(id);
            if (bug == null)
            {
                return ErrorResponse("Not found");
            }

            return Json(BugViewModelHelpers.ConvertToViewModel(bug));
        }

        /// <summary>
        /// Used to search all Book records with a given search string (searches against Book
        /// name, description and ISBN numbers)
        /// </summary>
        /// <param name="searchString">The search string to use</param>
        /// <returns>
        /// If Book records can be found, then a <see cref="BaseController.MultipleResults"/>
        /// is returned, which contains a collection of <see cref="bugTracker.Core.DTO.ViewModels.BugViewModel"/>.
        /// If no records can be found, then an <see cref="BaseController.ErrorResponse"/> is returned
        /// </returns>
        [HttpGet("Search")]
        public JsonResult Search(string searchString)
        {
            var bugs = _bugService.Search(searchString).ToList();

            if (!bugs.Any())
            {
                return ErrorResponse();
            }

            return Json(BugViewModelHelpers.ConvertToViewModels(bugs));
        }

        /// <summary>
        /// Used to assign a user to a bug
        /// </summary>
        /// <param name="bugId">The Id of the bug</param>
        /// <param name="userId">The ID of the user</param>
        /// <returns>An instance of a JsonResult result with a sucess/failure flag</returns>
        [HttpPost("SerUseronBug")]
        public async Task<JsonResult> SetUserOnBug(int bugId, int userId)
        {
            var success = await _bugService.SetAssignedUserForBug(bugId, userId);
            return MessageResult("Assign user action completed", success);
        }


        /// <summary>
        /// Used to create a new bug in the system
        /// </summary>
        /// <param name="bugToCreate">
        /// An instance of the <see cref="BugViewModel"/> class, containing all of the base data
        /// requried to create a new Bug in the system</param>
        /// <returns>An instance of a JsonResult result with a sucess/failure flag</returns>
        [HttpPost("CreateBug")]
        public async Task<JsonResult> CreateBug(BugViewModel bugToCreate)
        {
            var dbBug = BugViewModelHelpers.ConvertToDatabaseModel(bugToCreate);
            var newId = await _bugService.CreateBug(dbBug);
            return MessageResult($"Create bug action completed, new Id: {newId}", newId > 0);
        }


        /// <summary>
        ///  Used to delete a bug from the system (does not prompt for confirmation, obvs)
        /// </summary>
        /// <param name="bugId">The ID of the Bug to delete</param>
        /// <returns>An instance of a JsonResult result with a sucess/failure flag</returns>
        [HttpDelete("DeleteBug")]
        public async Task<JsonResult> DeleteBug(int bugId)
        {
            var success = await _bugService.DeleteBug(bugId);
            return MessageResult($"Deletion of Bug with ID {bugId} complete", success);
        }
    }
}