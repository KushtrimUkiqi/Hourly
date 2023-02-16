namespace Entities.EmployeeContext.Domain
{
    using Contracts.Common.ValueObjects;
    using Contracts.Common.DomainEntities;

    using Entities.EmployeeContext.ValueObjects;

    public partial class Employee : AggregateRoot
    {
        /// <summary>
        /// Employee uid
        /// </summary>
        public Guid Uid { get; private set; }

        /// <summary>
        /// Employee first name
        /// </summary>
        public EmployeeFirstNameValue FirstName { get; private set; }

        /// <summary>
        /// Employee last name
        /// </summary>
        public EmployeeLastNameValue LastName { get; private set; }

        /// <summary>
        /// Employee email address
        /// </summary>
        public EmailAddressValue EmailAddress { get; private set; }

        /// <summary>
        /// Employee phone number
        /// </summary>
        public PhoneNumberValue PhoneNumber { get; private set; }

        /// <summary>
        /// Employee position at the company
        /// </summary>
        public string? EmployeePosition { get; private set; }

        /// <summary>
        /// Tells if the employe is already part of the system or not "IsInvited" | "NotInvited"
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Tenant id
        /// </summary>
        public int TenantId { get; private set; }
    }
}
