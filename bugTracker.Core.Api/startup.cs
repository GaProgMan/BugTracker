using System.Linq;
using ClacksMiddleware.Extensions;
using bugTracker.Core.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace bugTracker.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                    {
                        "text/plain", "application/json"
                    });
            });

            services.AddCustomizedMvc();
            services.AddCorsPolicy();
            services.AddDbContext();
            services.AddTransientServices();
            services.AddSwagger($"v{CommonHelpers.GetVersionNumber()}");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.EnsureDatabaseIsSeeded(false);
            }

            // Only block and upgrade all insecure requests when not in dev
            // temporarily commented out, in order to get the docker container runnning
            app.UseSecureHeaders(env.IsProdOrStaging());
            app.UseResponseCaching();
            app.UseResponseCompression();
            app.GnuTerryPratchett();
            app.UseCorsPolicy();
            app.UseStaticFiles();
            
            app.UseSwagger($"/swagger/v{CommonHelpers.GetVersionNumber()}/swagger.json",
                $"bugTracker.Core {CommonHelpers.GetVersionNumber()}");
            
            app.UseCustomisedMvc();
        }
    }
}