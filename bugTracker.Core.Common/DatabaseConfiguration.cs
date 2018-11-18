using Microsoft.Extensions.Configuration;

namespace bugTracker.Core.Common
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private string DbConnectionKey = "bugTracker.CoreConnection";
        public string GetDatabaseConnectionString()
        {
            return GetConfiguration().GetConnectionString(DbConnectionKey);
        }
    }
}