namespace ReadOnlyStorage.Employee.Entities
{ 

    using Contracts.Common.Entities;

    public class Employee : BaseIdEntity
    {
        public Guid Uid { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        //public int UserId { get; set; }

        //public int TenantId { get; set; }
    }
}
