namespace IDP.Repository.EntitesConfiguration
{
    using IDP.Common.Entities;
    using IDP.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserEntityConfiguration : BaseIdEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("smalldatetime").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.Subject).HasColumnName("Subject").HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            builder.Property(x => x.UserName).HasColumnName("UserName").HasColumnType("nvarchar").HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("nvarchar").HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.SecurityCode).HasColumnName("SecurityCode").HasColumnType("nvarchar").HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.Active).HasColumnName("Active").HasColumnType("bit").IsRequired();
            builder.Property(x => x.SecurityCodeExpirationDate).HasColumnName("SecurityCodeExpirationDate").HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(x => x.ConcurrencyStamp).HasColumnName("ConcurrencyStamp").HasColumnType("nvarchar").HasMaxLength(200).IsRequired();


            builder.HasMany(x => x.Claims)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Logins)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Secrets)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId);
        }
    }
}
