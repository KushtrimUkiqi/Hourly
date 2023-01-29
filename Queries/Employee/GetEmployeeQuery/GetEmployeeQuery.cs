namespace Queries.Employee.GetEmployeeQuery
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Common.Results;
    using Contracts.Employee.Storage.Read;

    using MediatR;

    public class GetEmployeeQuery : IRequest<Result<EmployeeReponseDto>>
    {
        public Guid EmployeeUid { get; private set; }

        public GetEmployeeQuery(Guid employeeUid)
        {
            EmployeeUid = employeeUid;
        }
    }

    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Result<EmployeeReponseDto>>
    {
        private readonly IEmployeeReadOnlyRepository _employeeRepository;

        public GetEmployeeQueryHandler(IEmployeeReadOnlyRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<EmployeeReponseDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employeResult = _employeeRepository.GetEmployeeByUid(request.EmployeeUid);

            if(employeResult.IsFailure)
            {
                return Result<EmployeeReponseDto>.FROM_ERROR(employeResult);
            }

            return Result<EmployeeReponseDto>.OK(new EmployeeReponseDto
            {
                Uid = employeResult.Value.Uid,
                FirstName = employeResult.Value.FirstName,
                LastName= employeResult.Value.LastName
            });
        }
    }
}
