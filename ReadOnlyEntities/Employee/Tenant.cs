namespace ReadOnlyEntities.Employee
{
    using Contracts.Common.Entities;

    public class Tenant : BaseIdEntity
    {
        public Guid Uid { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
