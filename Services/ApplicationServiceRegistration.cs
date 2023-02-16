namespace Services
{
    using System.Reflection;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Contracts.Common.Infrastructure;

    using Services.Common;

    using MediatR;

    using MassTransit;

    using Microsoft.Extensions.Options;
    using Contracts.Common.Settings;

    public static class ApplicationServicesServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // configure settings
            services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<EmailSettings>>().Value);

            services.Configure<MessageBrokerSettings>(configuration.GetSection(nameof(MessageBrokerSettings)));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

            // add mediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // add mass transit
            services.AddMassTransit(busConfigurator =>
            {
                //busConfigurator.UsingRabbitMq();

                busConfigurator.SetKebabCaseEndpointNameFormatter();

                // might need to add check for seeing if it is in development or not, since on production we can use other message queues !
                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host("amqp://guest:guest@localhost:5672");

                    //MessageBrokerSettings messageBrokerSettings = context.GetRequiredService<MessageBrokerSettings>();

                    //configurator.Host(new Uri(messageBrokerSettings.Host), hostConfigurator =>
                    //{
                    //    hostConfigurator.Username(messageBrokerSettings.Username);
                    //    hostConfigurator.Password(messageBrokerSettings.Password);
                    //});

                });
            });

            // add services
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEventBus, EventBus>();

            return services;
        }
    }
}
