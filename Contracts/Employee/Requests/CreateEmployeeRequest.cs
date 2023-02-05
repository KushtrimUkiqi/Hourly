namespace Contracts.Employee.Requests
{
    public class CreateEmployeeRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Position { get; set; }

        public CreateEmployeeRequest(){}

        public CreateEmployeeRequest(string firstName, string lastName, string email, string phoneNumber, string position)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Position = position;
        }
    }
}
