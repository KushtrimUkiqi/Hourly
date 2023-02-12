namespace Storage.Tenant.StorageEntities
{

    using Contracts.Common.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class Tenant : BaseIdEntity
    {
        public Guid Uid { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? WebSite { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

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

            builder.HasMany(x => x.Employees)
                .WithOne(x => x.Tenant)
                .HasForeignKey(x => x.TenantId);
        }
    }
}
