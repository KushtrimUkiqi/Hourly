namespace IDP.Repository.EntitesConfiguration
{
    using IDP.Common.BaseEntities;
    using IDP.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserSecretEntityConfiguration : BaseIdEntityConfiguration<UserSecret>
    {
        public override void Configure(EntityTypeBuilder<UserSecret> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserSecret", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Secret).HasColumnName("Secret").HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.ConcurrencyStamp).HasColumnName("ConcurrencyStamp").HasColumnType("nvarchar").HasMaxLength(200).IsRequired();

            builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.User)
                    .WithMany(x => x.Secrets)
                    .HasForeignKey(x => x.UserId);
        }

    }
}
