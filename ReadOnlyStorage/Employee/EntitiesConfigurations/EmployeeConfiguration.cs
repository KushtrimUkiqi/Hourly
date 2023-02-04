﻿namespace ReadOnlyStorage.Employee.Entities
{
    using Contracts.Common.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
        }
    }
}