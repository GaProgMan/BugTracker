using System;
using System.Collections.Generic;
using System.Linq;
using bugTracker.Core.DTO.ViewModels;
using bugTracker.Core.Entities;
using bugTracker.Core.Enums;

namespace bugTracker.Core.DTO.Helpers
{
    public static class BugViewModelHelpers
    {
        public static BugViewModel ConvertToViewModel (Bug dbModel)
        {
            var viewModel = new BugViewModel
            {
                Id = dbModel.Id,
                Description = dbModel.Description,
                Title = dbModel.Title,
                Status = ConvertDbStatusToViewModelStatus(dbModel.Status),
                Created = dbModel.Created
            };

            if (dbModel.AssignedUser != null)
            {
                viewModel.AssignedUser = UserViewModelHelpers.ConvertToViewModel(dbModel.AssignedUser);
            }

            return viewModel;
        }

        private static bugTracker.Core.ViewModels.Enums.BugStatus ConvertDbStatusToViewModelStatus(bugTracker.Core.Enums.BugStatus dbStatus)
        {
            switch (dbStatus)
            {
                case bugTracker.Core.Enums.BugStatus.Open:
                    return bugTracker.Core.ViewModels.Enums.BugStatus.Open;
                case bugTracker.Core.Enums.BugStatus.Closed:
                    return bugTracker.Core.ViewModels.Enums.BugStatus.Closed;
                case bugTracker.Core.Enums.BugStatus.Fixed:
                    return bugTracker.Core.ViewModels.Enums.BugStatus.Fixed;
                case bugTracker.Core.Enums.BugStatus.NotGoingToFix:
                    return bugTracker.Core.ViewModels.Enums.BugStatus.NotGoingToFix;
                default:
                    return bugTracker.Core.ViewModels.Enums.BugStatus.Unknown;
            }
        }

        public static Bug ConvertToDatabaseModel (BugViewModel viewModel)
        {
            return new Bug
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                AssignedUserId = viewModel.AssignedUser.Id
            };
        }

        public static List<BugViewModel> ConvertToViewModels(List<Bug> dbModel)
        {
            return dbModel.Select(ConvertToViewModel).ToList();
        }
    }
}