using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        //register services related to application layer(mediator, validator...)
        public static IServiceCollection AddApplicationServices (this IServiceCollection services) //"this" makes it extension method for Services in Program.cs
        {
            services.AddMediatR(cfg =>
            {
                //auto registration of all handlers
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
