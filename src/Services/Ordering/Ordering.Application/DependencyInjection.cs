using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        //register services related to application layer(mediator, validator...)
        public static IServiceCollection AddApplicationServices
                (this IServiceCollection services) //"this" makes it extension method
        {
            //services.AddMediatR(cfg => {
            //    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //});

            return services;
        }
    }
}
