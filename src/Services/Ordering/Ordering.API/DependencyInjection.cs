namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIpiServices
        (this IServiceCollection services)
        {
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            return app;
        }
    }
}
