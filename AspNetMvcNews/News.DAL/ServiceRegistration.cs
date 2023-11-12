using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.DAL.Configurations;
using News.DAL.Contexts;

namespace News.DAL
{
    public static class ServiceRegistration
    {
        public static void AddDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration.Configure(configuration);
            services.AddDbContext<NewsDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
    }
}
