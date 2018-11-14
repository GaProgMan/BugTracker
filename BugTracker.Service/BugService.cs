using System.Collections.Generic;
using BugTracker.Data.Entities;
using BugTracker.Repo.Data;
using BugTracker.Service.Interfaces;

namespace BugTracker.Service
{
    public class BugService : IBugService
    {
        private readonly IRepository<Bug> _BugRepository;

        public BugService(IRepository<Bug> BugRepository)
        {
            _BugRepository = BugRepository;
        }

        public IEnumerable<Bug> GetBugs()
        {
            return _BugRepository.GetAll();
        }

        public Bug GetBug(int id)
        {
            return _BugRepository.Get(id);
        }

        public void InsertBug(Bug Bug)
        {
            _BugRepository.Insert(Bug);
        }

        public void UpdateBug(Bug Bug)
        {
            _BugRepository.Update(Bug);
        }

        public void DeleteBug(int id)
        {
            var bug = _BugRepository.Get(id);
            _BugRepository.Delete(bug);
            _BugRepository.SaveChanges();
        }
    }
}