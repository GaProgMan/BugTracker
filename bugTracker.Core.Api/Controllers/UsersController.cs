using Microsoft.AspNetCore.Mvc;
using System.Linq;
using bugTracker.Core.DAL;
using bugTracker.Core.DTO.Helpers;

namespace bugTracker.Core.Controllers
{
    [Route("/[controller]")]
    [Produces("application/json")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Used to get a user by its Id
        /// </summary>
        /// <param name="id">The ID of a user to return</param>
        /// <returns>
        /// If a bug can be found, then a <see cref="BaseController.SingleResult"/>
        /// is returned, which contains a <see cref="bugTracker.Core.DTO.ViewModels.BugViewModel"/>.
        /// If no record can be found, then an <see cref="BaseController.ErrorResponse"/> is returned
        /// </returns>
        [HttpGet("Get/{id}")]
        public JsonResult GetById(int id)
        {
            var user = _userService.FindById(id);
            if (user == null)
            {
                return ErrorResponse("Not found");
            }

            return SingleResult(UserViewModelHelpers.ConvertToViewModel(user));
        }

        /// <summary>
        /// Used to get all users in the system as a List of <see cref="UserViewModel" /> instances
        /// </summary>
        /// If user records can be found, then a <see cref="BaseController.MultipleResults"/>
        /// is returned, which contains a collection of <see cref="bugTracker.Core.DTO.ViewModels.UserViewModel"/>.
        /// If no records can be found, then an <see cref="BaseController.ErrorResponse"/> is returned
        /// </returns>
        [HttpGet("Search")]
        public JsonResult GetAll()
        {
            var users = _userService.GetAllUsers().ToList();

            if (!users.Any())
            {
                return ErrorResponse();
            }

            return MultipleResults(UserViewModelHelpers.ConverToViewModels(users));
        }
    }
}