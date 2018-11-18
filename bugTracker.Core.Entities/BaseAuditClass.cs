using System;

namespace bugTracker.Core.Entities
{
    public class BaseAuditClass 
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}