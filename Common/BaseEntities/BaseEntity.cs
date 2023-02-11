namespace IDP.Common.BaseEntities
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }

    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasQueryFilter(x => x.DeletedOn == null);
        }
    }
}
