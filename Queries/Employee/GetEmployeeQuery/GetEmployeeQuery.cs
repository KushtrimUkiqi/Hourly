namespace Queries.Employee.GetEmployeeQuery
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Common.Results;
    using Contracts.Employee.Responses;
    using Contracts.Employee.Storage.Read;

    using MediatR;

    public class GetEmployeeQuery : IRequest<Result<EmployeeResponseDto>>
    {
        public Guid EmployeeUid { get; private set; }

        public Guid TenantUid { get; private set; }

        public GetEmployeeQuery(Guid employeeUid, Guid tenantUid)
        {
            EmployeeUid = employeeUid;
            TenantUid = tenantUid;
        }
    }

    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Result<EmployeeResponseDto>>
    {
        private readonly IEmployeeReadOnlyRepository _employeeRepository;

        public GetEmployeeQueryHandler(IEmployeeReadOnlyRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<EmployeeResponseDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employeResult = await _employeeRepository.GetEmployeeByUidAsync(
                tenantUid: request.TenantUid,
                employeeUid: request.EmployeeUid);

            if(employeResult.IsFailure || employeResult.Value == null)
            {
                return Result<EmployeeResponseDto>.FROM_ERROR(employeResult);
            }

            return Result<EmployeeResponseDto>.OK(new EmployeeResponseDto
            {
                Uid = employeResult.Value.Uid,
                FirstName = employeResult.Value.FirstName ?? string.Empty,
                LastName= employeResult.Value.LastName ?? string.Empty,
                PhoneNumber = employeResult.Value.PhoneNumber ?? string.Empty ,
                Email = employeResult.Value.Email ?? string.Empty,
                Status = employeResult.Value.Status,
            });
        }
    }
}
