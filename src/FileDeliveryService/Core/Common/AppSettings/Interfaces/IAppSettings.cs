using FileDeliveryService.Common.Cors;

namespace FileDeliveryService.Common.AppSettings.Interfaces
{
    public interface IAppSettings
    {
        public string ConnectionString { get; }

        public CorsSettings CorsSettings { get; }
    }
}
