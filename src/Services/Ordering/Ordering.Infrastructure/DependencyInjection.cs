using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ordering.Infrastructure
{
    //register all dependencies of Infrastructure layer( db context, repositories, external api..)
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
              (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            // Add services to the container.
            services.AddDbContext<ApplicationDbContext>((sp, opt) =>
            {
                //add all interceptors and sql
                opt.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                opt.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
