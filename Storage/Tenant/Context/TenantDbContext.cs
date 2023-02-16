namespace Storage.Tenant.Context
{
    using Microsoft.EntityFrameworkCore;

    using Storage.Tenant.StorageEntities;

    public class TenantDbContext : DbContext
    {
        private DbSet<Tenant> tenants;

        private DbSet<Employee> employees;

        public TenantDbContext(DbContextOptions<TenantDbContext> options)
           : base(options)
        { }

        public DbSet<Tenant> Tenants => tenants ??= Set<Tenant>();

        public DbSet<Employee> Employees => employees ??= Set<Employee>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TenantConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());


            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
