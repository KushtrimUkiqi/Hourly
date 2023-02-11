namespace IDP.Services
{
    using IDP.Services.Implementation;
    using IDP.Services.Interfaces;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServicesServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        { 
            // add services
            services.AddTransient<ILocalUserService, LocalUserService>();
            services.AddTransient<ILocalUserProfileService, LocalUserProfileService>();

            return services;
        }
    }
}
