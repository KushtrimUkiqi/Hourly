namespace Storage.Tenant.StorageEntities
{
    using Contracts.Common.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class Employee : BaseIdEntity
    {
        public Guid Uid { get; set; }

        public int TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }
    }

    public class EmployeeConfiguration : BaseIdEntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.ToTable("Employee", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("guid").IsRequired();

            builder.Property(x => x.TenantId).HasColumnName("TenantId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Tenant)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.TenantId);
        }
    }
}
