using System;

namespace BugTracker.Data.Entities
{
    public abstract class BaseAuditClass
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

}