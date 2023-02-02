namespace Services
{
    using System.Reflection;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Contracts.Common.Models;
    using Contracts.Common.Infrastructure;

    using Services.Common;

    using MediatR;

    public static class ApplicationServicesServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // add mediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // configure services
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            // add services
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
