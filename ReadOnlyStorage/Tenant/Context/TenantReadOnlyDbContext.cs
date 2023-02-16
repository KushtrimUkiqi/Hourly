namespace ReadOnlyStorage.Tenant.Context
{
    using Microsoft.EntityFrameworkCore;

    using ReadOnlyEntities.Tenant;
    using ReadOnlyStorage.Tenant.EntitiesConfiguration;

    public class TenantReadOnlyDbContext : DbContext
    {
        private DbSet<Tenant> tenants;

        public TenantReadOnlyDbContext(DbContextOptions<TenantReadOnlyDbContext> options)
           : base(options)
        { }

        public IQueryable<Tenant> Tenants
        {
            get
            {
                if (tenants == null)
                {
                    return Set<Tenant>().AsNoTracking();
                }

                return tenants.AsNoTracking();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TenantConfiguration());

            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
