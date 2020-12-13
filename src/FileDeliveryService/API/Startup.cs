using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using API.Configs;
using API.Filters;
using API.Middleware.ExceptionHandler;
using API.Services;

namespace API
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
            services.AddMediator();
            services.AddServices(Configuration);
            services.AddDatabaseConfiguration(Configuration);
            services.AddRepositories();
            services.AddCorsPolicy(Configuration);

            services.AddMvc(o => 
            {
                o.Filters.Add(new RequestBodyFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var appSettings = app.ProvideAppSettings();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            // Exception handler needs to be after https redirection !!!
            app.UseMiddleware<ExceptionHandler>();

            app.UseRouting();
            app.UseCors(appSettings.CorsSettings.CorsPolicyName);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
