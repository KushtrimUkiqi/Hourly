namespace Storage.Employee.Context
{
    using Microsoft.EntityFrameworkCore;

    using Storage.Employee.StorageEntities;

    public class EmployeeDbContext : DbContext
    {
        private DbSet<Employee> employees;

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
           : base(options)
        { }

        public DbSet<Employee> Employees => employees ??= Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
