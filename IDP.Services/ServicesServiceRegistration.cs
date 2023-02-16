namespace IDP.Services
{
    using IDP.Domain.IntegrationEvents;
    using IDP.Services.Implementation;
    using IDP.Services.IntegrationEventHandlers;
    using IDP.Services.Interfaces;
    using MassTransit;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServicesServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            // add mass transit with rabbit mq
            services.AddMassTransit(busConfigurator =>
            {

                //busConfigurator.AddConsumer<EmployeeInviteRequestedIntegrationEventHandler>();

                busConfigurator.AddConsumer<EmployeeInviteRequestedIntegrationEventHandler>();

                //busConfigurator.SetKebabCaseEndpointNameFormatter();

                //// might need to add check for seeing if it is in development or not, since on production we can use other message queues !
                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    //MessageBrokerSettings messageBrokerSettings = context.GetRequiredService<MessageBrokerSettings>();

                    //configurator.Host(new Uri(messageBrokerSettings.Host), hostConfigurator =>
                    //{
                    //    hostConfigurator.Username(messageBrokerSettings.Username);
                    //    hostConfigurator.Password(messageBrokerSettings.Password);
                    //});

                    configurator.Host("amqp://guest:guest@localhost:5672");

                    configurator.ReceiveEndpoint("hourly-employees-queue", c =>
                    {
                        //c.Handler<EmployeeInviteRequestedIntegrationEvent>(ctx =>
                        //{
                        //   return Console.Out.WriteLineAsync("Hello");
                        //});

                        c.ConfigureConsumer<EmployeeInviteRequestedIntegrationEventHandler>(context);
                    });

                });
            });
            // add services
            services.AddScoped<ILocalUserService, LocalUserService>();
            services.AddScoped<ILocalUserProfileService, LocalUserProfileService>();

            return services;
        }
    }
}
