namespace Storage.Employee.Context
{
    using Microsoft.EntityFrameworkCore;

    using Storage.Employee.StorageEntities;

    public class EmployeeDbContext : DbContext
    {
        private DbSet<Employee> employees;
        private DbSet<Tenant> tenants;

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
           : base(options)
        {
            employees = Set<Employee>();
            tenants = Set<Tenant>();
        }

        public DbSet<Employee> Employees => employees ??= Set<Employee>();
        public DbSet<Tenant> Tenants => tenants ??= Set<Tenant>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new TenantConfiguration());

            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
