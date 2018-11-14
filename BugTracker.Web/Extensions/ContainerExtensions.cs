using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BugTracker.Repo;
using BugTracker.Repo.Data;
using BugTracker.Repo.Identity;
using BugTracker.Service;
using BugTracker.Service.Interfaces;

namespace BugTracker.Web
{
    public static class ConfigureContainerExtensions
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
            string dataConnectionString = null, string authConnectionString = null)
        {
            serviceCollection.AddDbContext<DataContext>(options =>
                options.UseSqlite(dataConnectionString ?? GetDataConnectionStringFromConfig()));

            serviceCollection.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlite(authConnectionString ?? GetAuthConnectionFromConfig()));

            serviceCollection.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();
        }
        
        public static void AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBugService, BugService>();

            serviceCollection.AddTransient<IEmailSender, EmailSender>();
        }
        
        private static string GetDataConnectionStringFromConfig()
        {
            return new DatabaseConfiguration().GetDataConnectionString();
        }

        private static string GetAuthConnectionFromConfig()
        {
            return new DatabaseConfiguration().GetAuthConnectionString();
        }
    }
}