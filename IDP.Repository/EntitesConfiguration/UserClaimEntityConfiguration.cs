namespace IDP.Repository.EntitesConfiguration
{
    using IDP.Common.Entities;
    using IDP.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserClaimEntityConfiguration : BaseIdEntityConfiguration<UserClaim>
    {
        public override void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserClaim", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.Type).HasColumnName("Type").HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Value).HasColumnName("Value").HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.ConcurrencyStamp).HasColumnName("ConcurrencyStamp").HasColumnType("nvarchar").HasMaxLength(200).IsRequired();

            builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.User)
                    .WithMany(x => x.Claims)
                    .HasForeignKey(x => x.UserId);
        }

    }
}
