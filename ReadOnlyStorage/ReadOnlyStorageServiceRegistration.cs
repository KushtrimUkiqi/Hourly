namespace ReadOnlyStorage
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Contracts.Employee.Storage.Read;

    using ReadOnlyStorage.Employee.Context;
    using ReadOnlyStorage.Employee.Repository;
    using ReadOnlyStorage.Tenant.Context;
    using Queries.Tenant.Repository;
    using ReadOnlyStorage.Tenant.Repository;

    public static class ReadOnlyStorageServiceRegistration
    {
        public static IServiceCollection AddReadOnlyStorageServices(this IServiceCollection services, IConfiguration configuration)
        {
            // db contexts registrations
            services.AddDbContext<EmployeeReadOnlyDbContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("ReadOnlyConnectionString")));


            services.AddDbContext<TenantReadOnlyDbContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("ReadOnlyConnectionString")));

            // repositories registrations
            services.AddScoped<IEmployeeReadOnlyRepository, EmployeeReadOnlyRepository>();
            services.AddScoped<ITenantReadOnlyRepository, TenantReadOnlyRepository>();

            return services;
        }
    }
}
