using System.Collections.Generic;
using System.Linq;
using bugTracker.Core.DTO.ViewModels;
using bugTracker.Core.Entities;

namespace bugTracker.Core.DTO.Helpers
{
    public static class UserViewModelHelpers
    {
        public static UserViewModel ConvertToViewModel(User dbModel)
        {
            return new UserViewModel
            {
                Username = dbModel.Username,
                Id = dbModel.Id
            };
        }

        public static List<UserViewModel> ConverToViewModels(List<User> dbModels)
        {
            return dbModels.Select(ConvertToViewModel).ToList();
        }
    }
}