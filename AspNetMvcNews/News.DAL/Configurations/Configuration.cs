using Microsoft.Extensions.Configuration;

namespace News.DAL.Configurations
{
    public class Configuration
    {
        private static IConfiguration _configuration;

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string ConnectionString => _configuration.GetConnectionString("NewsDB");
    }
}
