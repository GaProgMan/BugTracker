using System.Collections.Generic;
using System.Collections.ObjectModel;
using bugTracker.Core.Enums;

namespace bugTracker.Core.Entities
{
    public class Bug : BaseAuditClass
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public int? AssignedUserId { get; set; }
        public virtual User AssignedUser { get ; set; }
    }
}