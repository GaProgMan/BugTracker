using System.Collections.Generic;
using bugTracker.Core.ViewModels.Enums;

namespace bugTracker.Core.DTO.ViewModels
{
    public class BugViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; }
        public UserViewModel AssignedUser { get; set; }
    }
}