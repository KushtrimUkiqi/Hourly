namespace Services.Employee.Commands.CreateEmployeeCommand
{
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Common.Results;

    using MediatR;

    public class CreateEmployeeCommand : IRequest<Result<Guid>>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public CreateEmployeeCommand(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return Result<Guid>.OK(Guid.NewGuid());
        }
    }
}
