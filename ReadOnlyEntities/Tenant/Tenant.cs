namespace ReadOnlyEntities.Tenant
{
    using Contracts.Common.Entities;

    public class Tenant : BaseIdEntity
    {
        public Guid Uid { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? WebSite { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
