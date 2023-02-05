namespace Services.Employee.Commands.CreateEmployeeCommand
{
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Common.Results;
    using Services.Employee.Repository;
    using Entities.EmployeeContext.Domain;

    using MediatR;
    using Contracts.Employee.Requests;

    public class CreateEmployeeCommand : IRequest<Result<Guid>>
    {

        public CreateEmployeeRequest Request { get; set; }

        public CreateEmployeeCommand(CreateEmployeeRequest request)
        {
            Request = request;
        }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Guid>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Result<Employee> employeeCreatedResult = Employee.Create(
                firstName: request.Request.FirstName,
                lastName: request.Request.LastName,
                email: request.Request.Email,
                phoneNumber: request.Request.PhoneNumber,
                position: request.Request.Position);

            if(employeeCreatedResult.IsFailure)
            {
                return Result<Guid>.FROM_ERROR(employeeCreatedResult);
            }

            Result employeeAddedResult = await _employeeRepository.AddAsync(employeeCreatedResult.Value);

            if(employeeAddedResult.IsFailure)
            {
                return Result<Guid>.FROM_ERROR(employeeAddedResult);
            }

            await _employeeRepository.SaveChangesAsync();

            return Result<Guid>.OK(employeeCreatedResult.Value.Uid);
        }
    }
}
