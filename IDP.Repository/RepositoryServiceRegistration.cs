namespace IDP.Repository
{
    using IDP.Repository.DbContext;
    using IDP.Repository.Interfaces;
    using IDP.Repository.Implementation;
    using IDP.Common.Contracts.IUnitOfWork;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class RepositoryServiceRegistration
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            // db contexts registrations
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("DataBaseConnectionString")));

            // repositories registrations
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserLoginsRepository, UserLoginsRepository>();

            // unit of work registration
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
