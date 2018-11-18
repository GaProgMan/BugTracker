using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bugTracker.Core.Entities;
using bugTracker.Core.Persistence;

namespace bugTracker.Core.DAL
{
    public class BugService : BaseService, IBugService
    {
        private readonly BugContext _bugContext;

        public BugService (BugContext bugContext) :base(bugContext)
        {
            _bugContext = bugContext;
        }

        public Bug FindById(int id)
        {
            return BaseReadOnlyBugQuery()
                .FirstOrDefault(bug => bug.Id == id);
        }

        public IEnumerable<Bug> Search(string searchKey)
        {
            var blankSearchString = string.IsNullOrWhiteSpace(searchKey);

            var results = BaseReadOnlyBugQuery();

            if (!blankSearchString)
            {
                searchKey = searchKey.ToLower();
                results = results
                    .Where(bug => bug.Title.ToLower().Contains(searchKey)
                        || bug.Description.ToLower().Contains(searchKey));
            }
                

            return results.OrderBy(bug => bug.Created);
        }

        public async Task<bool> SetAssignedUserForBug(int bugId, int userId)
        {
            var foundBug = BaseWritableBugQuery().FirstOrDefault(bug => bug.Id == bugId);
            var foundUser = BaseReadOnlyUserQuery().FirstOrDefault(user => user.Id == userId);

            if (foundBug == null || foundUser == null)
            {
                throw new ArgumentException($"Unable to find User or Bug (Params: bugId {bugId}; userid {userId})");
            }

            foundBug.AssignedUserId = foundUser.Id;
            var alteredRecordsCount = await _bugContext.SaveChangesAsync();
            return alteredRecordsCount > 0;
        }

        public async Task<int> CreateBug(Bug bugToSave)
        {
            await _bugContext.Bugs.AddAsync(bugToSave);
            var alteredRecordsCount = await _bugContext.SaveChangesAsync();
            return alteredRecordsCount > 0
                ? BaseReadOnlyBugQuery().FirstOrDefault(bug => bug.Title == bugToSave.Title).Id
                : -1;
        }

        public async Task<bool> DeleteBug(int bugId)
        {
            var bug = FindById(bugId);
            if (bug == null)
            {
                return false;
            }
            _bugContext.Bugs.Remove(bug);
            var alteredRecordsCount = await _bugContext.SaveChangesAsync();
            return alteredRecordsCount > 0;
        }
    }
}