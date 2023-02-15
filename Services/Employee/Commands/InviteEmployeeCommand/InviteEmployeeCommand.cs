namespace Services.Employee.Commands.EmployeeInvitedCommand 
{ 
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Common.Results;
    using Services.Employee.Repository;

    using MediatR;

    public class InviteEmployeeCommand : IRequest<Result>
    {
        public Guid TenantUid { get; set; }

        public Guid EmployeeUid { get; set; }

        public InviteEmployeeCommand(Guid tenantUid, Guid employeeUid)
        {
            TenantUid = tenantUid;
            EmployeeUid = employeeUid;
        }
    }

    public class InviteEmployeeCommandHandler : IRequestHandler<InviteEmployeeCommand, Result>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public InviteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result> Handle(InviteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeResult = await _employeeRepository.GetEmployeeByUidAsync(tenantUid: request.TenantUid, employeeUid: request.EmployeeUid);

            if (employeeResult.IsFailure || employeeResult.Value == null)
            {
                return employeeResult;
            }

            var inviteEmployeeResult =  employeeResult.Value.Invite();


            if(inviteEmployeeResult.IsFailure)
            {
                return inviteEmployeeResult;
            }

            Result updatedResult = await _employeeRepository.UpdateAsync(employeeResult.Value);

            if (updatedResult.IsFailure)
            {
                return Result<Guid>.FROM_ERROR(updatedResult);
            }

            await _employeeRepository.SaveChangesAsync();

            return Result.OK();
        }
    }
}
