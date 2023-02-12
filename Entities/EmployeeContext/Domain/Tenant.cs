namespace Entities.EmployeeContext.Domain
{
    using Contracts.Common.DomainEntities;

    public partial class Tenant : AggregateRoot
    {
        private readonly List<Employee> _employees = new();

        public Guid Uid { get; private set; }

        public IReadOnlyList<Employee> Employees => _employees.AsReadOnly();
    }
}
