using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using FileDeliveryService.Common.AppSettings.Interfaces;

namespace API.Services
{
    public static class ServiceProviderExtensions
    {
        public static IAppSettings ProvideAppSettings(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            return provider.ProvideAppSettings();
        }

        public static IAppSettings ProvideAppSettings(this IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<IAppSettings>();
        }

        public static IAppSettings ProvideAppSettings(this IApplicationBuilder app)
        {
            return app.ApplicationServices.ProvideAppSettings();
        }
    }
}
