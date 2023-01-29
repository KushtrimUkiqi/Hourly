namespace Queries.Employee.GetEmployeesQuery
{
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Common.Results;
    using Contracts.Common.Responses;
    using Contracts.Employee.Storage.Read;

    using MediatR;

    public class GetEmployeesQuery : IRequest<Result<PageListResponse<EmployeeReponseDto>>>
    {
        public int PageSize { get; set; }

        public int Page { get; set; }
    }

    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, Result<PageListResponse<EmployeeReponseDto>>>
    {
        private IEmployeeReadOnlyRepository _readEmployeeRepository;

        public GetEmployeesQueryHandler(IEmployeeReadOnlyRepository readEmployeeRepository)
        {
            _readEmployeeRepository = readEmployeeRepository;
        }

        public async Task<Result<PageListResponse<EmployeeReponseDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return Result<PageListResponse<EmployeeReponseDto>>.NOT_FOUND("SDSDSD");
        }
    }
}
