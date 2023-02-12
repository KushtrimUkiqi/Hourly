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
        public Guid TenantUid { get; set; }

        public CreateEmployeeRequest Request { get; set; }

        public CreateEmployeeCommand(Guid tenantUid, CreateEmployeeRequest request)
        {
            TenantUid = tenantUid;
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
            var tenantResult = await _employeeRepository.GetTenantByUidAsync(request.TenantUid);
            
            if(tenantResult.IsFailure || tenantResult.Value == null)
            {
                return Result<Guid>.FROM_ERROR(tenantResult);
            }

            Result<Employee> employeeCreatedResult = Employee.Create(
                firstName: request.Request.FirstName,
                lastName: request.Request.LastName,
                email: request.Request.Email,
                phoneNumber: request.Request.PhoneNumber,
                position: request.Request.Position,
                tenantId: tenantResult.Value.Id);

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
