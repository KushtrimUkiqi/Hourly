namespace ReadOnlyEntities.Tenant
{

    using Contracts.Common.Entities;

    public class Employee : BaseIdEntity
    {
        public Guid Uid { get; set; }

        public int UserId { get; set; }

        public int TenantId { get; set; }

        public virtual Tenant? Tenant { get; set; }
    }
}
