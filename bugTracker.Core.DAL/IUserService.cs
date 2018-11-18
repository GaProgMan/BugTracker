using System.Collections.Generic;
using bugTracker.Core.Entities;

namespace bugTracker.Core.DAL
{
    public interface IUserService
    {
        User FindById(int id);
        IEnumerable<User> GetAllUsers();
    }
}