using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentValidation;

using FileDeliveryService.Common.Mediator.Interfaces;
using FileDeliveryService.Common.Mediator;
using FileDeliveryService.Common.AppSettings;
using FileDeliveryService.Common.AppSettings.Interfaces;
using FileDeliveryService.Persistence.DatabaseContext;
using FileDeliveryService.Persistence.Repositories.Interfaces;
using FileDeliveryService.Persistence.Repository;
using FileDeliveryService.Service.FileDelivery.Commands;
using FileDeliveryService.Persistence.Storage.Interfaces;
using FileDeliveryService.Persistence.Storage;
using FileDeliveryService.Service.FileDelivery.Validators;
using FileDeliveryService.Persistence.Repositories;
using FileDeliveryService.Common.ValidationBehavior;

namespace API.Configs
{
    public static class RegisterServices
    {
        public static void AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings(configuration);

            services.AddCors(options =>
            {
                options.AddPolicy(name: appSettings.CorsSettings.CorsPolicyName, builder =>
                {
                    builder.WithOrigins(appSettings.CorsSettings.AppDefaultClientUrl)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPacketRepository, PacketRepository>();
            services.AddScoped<IVersionRepository, VersionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings(configuration);

            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(appSettings.ConnectionString);
            });
        }

        public static void AddMediator(this IServiceCollection services)
        {
            services.AddScoped<IMediatorService, MediatorService>();
            services.AddMediatR(typeof(GetPaginatedPackets));
        }

        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings(configuration);

            services.AddSingleton<IAppSettings>(provider => appSettings);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(UpdatePacketValidator).GetTypeInfo().Assembly);
        }
    }
}
