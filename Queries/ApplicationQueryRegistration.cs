namespace Queries
{
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

    using MediatR;

    public static class ApplicationQueryRegistration
    {
        public static IServiceCollection AddAplicationQueryServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
