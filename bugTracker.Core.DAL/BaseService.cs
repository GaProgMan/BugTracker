using System.Collections.Generic;
using bugTracker.Core.Entities;
using bugTracker.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace bugTracker.Core.DAL
{
    public abstract class BaseService 
    {
        private readonly BugContext _bugContext;
        public BaseService(BugContext bugContext)
        {
            _bugContext = bugContext;
        }

        protected IEnumerable<Bug> BaseWritableBugQuery()
        {
            return _bugContext.Bugs
                .Include(bug => bug.AssignedUser);
        }

        protected IEnumerable<Bug> BaseReadOnlyBugQuery()
        {
            return _bugContext.Bugs
                .AsNoTracking()
                .Include(bug => bug.AssignedUser);
        }

        protected IEnumerable<User> BaseReadOnlyUserQuery()
        {
            return _bugContext.Users
                .AsNoTracking();
        }
    }
}