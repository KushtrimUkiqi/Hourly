namespace Contracts.Employee.Responses
{
    public class EmployeeResponseDto
    {
        public Guid Uid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }
    }
}