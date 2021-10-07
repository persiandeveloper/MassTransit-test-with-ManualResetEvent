using Microsoft.Extensions.DependencyInjection;
using MassTransit;

namespace Broker
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterBroker(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<MessageConsumer>();

                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
