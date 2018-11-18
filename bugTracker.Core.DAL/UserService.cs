using System.Collections.Generic;
using System.Linq;
using bugTracker.Core.Entities;
using bugTracker.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace bugTracker.Core.DAL
{
    public class UserService : BaseService, IUserService
    {
        private readonly BugContext _bugContext;
        public UserService(BugContext bugContext) :base (bugContext)
        {
            _bugContext = bugContext;
        }
        public User FindById(int id)
        {
            return BaseReadOnlyUserQuery()
                .FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return BaseReadOnlyUserQuery().OrderBy(user => user.Id);
        }
    }
}