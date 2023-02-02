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

        public GetEmployeeQuery(Guid employeeUid)
        {
            EmployeeUid = employeeUid;
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
            var employeResult = await _employeeRepository.GetEmployeeByUidAsync(request.EmployeeUid);

            if(employeResult.IsFailure)
            {
                return Result<EmployeeResponseDto>.FROM_ERROR(employeResult);
            }

            return Result<EmployeeResponseDto>.OK(new EmployeeResponseDto
            {
                Uid = employeResult.Value.Uid,
                FirstName = employeResult.Value.FirstName,
                LastName= employeResult.Value.LastName,
                PhoneNumber = employeResult.Value.PhoneNumber,
                Email = employeResult.Value.Email
            });
        }
    }
}
