using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Messaging.MassTransit
{
    public static class Extensions
    {
        //???
        //null cause it's not required for the publisher, but we send assembly in order to adding consumers into configuratuion(ordering)
        public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
        {
            //to setup mass transit in the service collection(it allows cinfiguration of rge message bus consumers, sagas ...)
            services.AddMassTransit(config =>
            {
                //sets the nameing convention for the endpoints
                config.SetKebabCaseEndpointNameFormatter();

                //when we are using ordering, this will be as a consumers that can trigger for the consumer opperation
                if (assembly != null)
                    config.AddConsumers(assembly);

                //reach rabbitmq host configurations
                //configure the bus to use rabbitmq as a transport
                config.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                    {
                        host.Username(configuration["MessageBroker:UserName"]);
                        host.Password(configuration["MessageBroker:Password"]);
                    });
                    configurator.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}
