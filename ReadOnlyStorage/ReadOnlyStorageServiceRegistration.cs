namespace ReadOnlyStorage
{
    using Contracts.Employee.Storage.Read;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using ReadOnlyStorage.Employee.Context;
    using ReadOnlyStorage.Employee.Repository;

    public static class ReadOnlyStorageServiceRegistration
    {
        public static IServiceCollection AddReadOnlyStorageServices(this IServiceCollection services, IConfiguration configuration)
        {
            // db contexts regristrations
            services.AddDbContext<EmployeeReadOnlyDbContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("ReadOnlyConnectionString")));

            // repositories registrations
            services.AddScoped<IEmployeeReadOnlyRepository, EmployeeReadOnlyRepository>();

            return services;
        }
    }
}
