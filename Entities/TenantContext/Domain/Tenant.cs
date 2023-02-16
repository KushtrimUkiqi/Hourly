namespace Entities.TenantContext.Domain
{
    using Contracts.Common.DomainEntities;

    public partial class Tenant : AggregateRoot
    {
        private readonly List<Employee> _employees = new();

        public Guid Uid { get; private set; }

        public string? Name { get; private set; }

        public string? Address { get; private set; }

        public string? WebSite { get; private set; }

        public IReadOnlyList<Employee> Employees => _employees.AsReadOnly();
    }
}
