using Microsoft.Extensions.Configuration;

namespace BugTracker.Repo
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private string DataConnectionKey = "bugTrackerDataConnection";

        private string AuthConnectionKey = "bugTrackerAuthConnection";

        public string GetDataConnectionString()
        {
            return GetConfiguration().GetConnectionString(DataConnectionKey);
        }
        
        public string GetAuthConnectionString()
        {
            return GetConfiguration().GetConnectionString(AuthConnectionKey);
        }
    }
}
