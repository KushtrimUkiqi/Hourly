namespace Storage
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Services.Employee.Repository;
    using Services.Tenant.Repository;

    using Storage.Employee.Context;
    using Storage.Employee.Repositories;
    using Storage.Tenant.Context;
    using Storage.Tenant.Repositories;

    public static class StorageServiceRegistration
    {
        public static IServiceCollection AddStorageServices(this IServiceCollection services, IConfiguration configuration)
        {
            // db contexts regristrations
            services.AddDbContext<EmployeeDbContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("ReadWriteConnectionString")));

            services.AddDbContext<TenantDbContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("ReadWriteConnectionString")));

            // repositories registrations
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();

            return services;
        }
    }
}
