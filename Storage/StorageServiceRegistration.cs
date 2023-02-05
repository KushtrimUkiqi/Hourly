namespace Storage
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Services.Employee.Repository;

    using Storage.Employee.Context;
    using Storage.Employee.Repositories;

    public static class StorageServiceRegistration
    {
        public static IServiceCollection AddStorageServices(this IServiceCollection services, IConfiguration configuration)
        {
            // db contexts regristrations
            services.AddDbContext<EmployeeDbContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("ReadWriteConnectionString")));

            // repositories registrations
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
