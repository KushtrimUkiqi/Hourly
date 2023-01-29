namespace Contracts.Common.Entities
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseIdEntity : BaseEntity 
    {
        public int Id { get; set; }
    }

    public class BaseIdEntityConfiguration<T> : BaseEntityConfiguration<T> 
        where T : BaseIdEntity 
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => e.Id);
        }
    }
}
