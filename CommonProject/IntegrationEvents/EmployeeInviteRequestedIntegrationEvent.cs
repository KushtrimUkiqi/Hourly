namespace CommonProject.IntegrationEvents
{
    /// <summary>
    /// Integration event raised when an employee needs to be invited to be user of the system
    /// </summary>
    public class EmployeeInviteRequestedIntegrationEvent
    {
        public int TenantId { get; set; }

        public Guid EmployeeUid { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string TenantName { get; set; }

        public EmployeeInviteRequestedIntegrationEvent(
            int tenantId,
            Guid employeeUid,
            string email,
            string name,
            string tenantName)
        {
            TenantId = tenantId;
            EmployeeUid = employeeUid;
            Email = email;
            Name = name;
            TenantName = tenantName;
        }
    }
}
