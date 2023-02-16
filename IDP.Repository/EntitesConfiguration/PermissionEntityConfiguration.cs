namespace IDP.Repository.EntitesConfiguration
{
    using IDP.Common.BaseEntities;
    using IDP.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PermissionEntityConfiguration : BaseIdEntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder.ToTable("Permission", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(255).IsRequired();

            builder.Property(x => x.RoleId).HasColumnName("RoleId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Role)
                    .WithMany(x => x.Permissions)
                    .HasForeignKey(x => x.RoleId);
        }

    }
}
