using Microsoft.Extensions.Configuration;

namespace BranchProductApp.Core.Helpers
{
    public static class ConfigHelper
    {
        public static string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string not found in sharedsettings.json");
            }

            return connectionString;
        }
    }
}
