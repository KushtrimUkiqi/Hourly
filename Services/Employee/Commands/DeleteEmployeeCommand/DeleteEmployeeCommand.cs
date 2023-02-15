namespace Services.Employee.Commands.DeleteEmployeeCommand
{
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Common.Results;
    using Services.Employee.Repository;

    using MediatR;

    public class DeleteEmployeeCommand : IRequest<Result>
    {
        public Guid TenantUid { get; set; }

        public Guid EmployeeUid { get; set; }

        public DeleteEmployeeCommand(Guid tenantUid, Guid employeeUid)
        {
            TenantUid = tenantUid;
            EmployeeUid = employeeUid;
        }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeResult = await _employeeRepository.GetEmployeeByUidAsync(tenantUid: request.TenantUid, employeeUid: request.EmployeeUid);

            if(employeeResult.IsFailure || employeeResult.Value == null)
            {
                return employeeResult;
            }

            employeeResult.Value.MarkAsDeleted(dateTime: DateTime.UtcNow);


            Result employeeDeletedResult = await _employeeRepository.UpdateAsync(employeeResult.Value);

            if (employeeDeletedResult.IsFailure)
            {
                return Result<Guid>.FROM_ERROR(employeeDeletedResult);
            }

            await _employeeRepository.SaveChangesAsync();

            return Result.OK();
        }
    }
}
