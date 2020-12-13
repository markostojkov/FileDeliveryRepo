using Microsoft.Extensions.Configuration;

using FileDeliveryService.Common.AppSettings.Interfaces;
using FileDeliveryService.Common.Cors;

namespace FileDeliveryService.Common.AppSettings
{
    public class AppSettings : IAppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string ConnectionString => Configuration.GetConnectionString("FileDeliveryServiceSqlServerConnectionString");

        public CorsSettings CorsSettings
        {
            get
            {
                var corsSettings = new CorsSettings();
                Configuration.GetSection("CorsSettings").Bind(corsSettings);
                return corsSettings;
            }
        }
    }
}
