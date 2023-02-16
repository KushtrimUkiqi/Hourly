namespace ReadOnlyStorage.Employee.Context
{
    using Microsoft.EntityFrameworkCore;

    using ReadOnlyEntities.Employee;
    using ReadOnlyStorage.Employee.Entities;

    public  class EmployeeReadOnlyDbContext : DbContext
    {
        private DbSet<Employee> employees;

        public EmployeeReadOnlyDbContext(DbContextOptions<EmployeeReadOnlyDbContext> options)
           : base(options)
        {}

        //public DbSet<Employee> Employees => employees ??= Set<Employee>();

        public IQueryable<Employee> Employees
        {
            get
            {
                if (employees == null)
                {
                    return Set<Employee>().AsNoTracking();
                }

                return employees.AsNoTracking();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
