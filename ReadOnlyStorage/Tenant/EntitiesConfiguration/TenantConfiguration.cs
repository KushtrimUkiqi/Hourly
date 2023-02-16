namespace ReadOnlyStorage.Tenant.EntitiesConfiguration
{
    using ReadOnlyEntities.Tenant;
    using Contracts.Common.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TenantConfiguration : BaseIdEntityConfiguration<Tenant>
    {
        public override void Configure(EntityTypeBuilder<Tenant> builder)
        {
            base.Configure(builder);

            builder.ToTable("Tenant", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("guid").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Address).HasColumnName("Address").HasColumnType("nvarchar").HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.WebSite).HasColumnName("WebSite").HasColumnType("nvarchar").HasMaxLength(255).IsRequired(false);
        }
    }
}
