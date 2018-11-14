namespace BugTracker.Data.Entities
{
    public class Bug : BaseAuditClass
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

}