namespace Queries.Employee.GetEmployeesQuery
{
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Common.Results;
    using Contracts.Common.Responses;
    using Contracts.Employee.Responses;
    using Contracts.Employee.Storage.Read;

    using MediatR;

    public class GetEmployeesQuery : IRequest<Result<PageListResponse<EmployeeResponseDto>>>
    {
        public Guid TenantUid { get; set; }
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public GetEmployeesQuery(Guid tenantUid, int pageNumber, int pageSize)
        {
            TenantUid = tenantUid;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, Result<PageListResponse<EmployeeResponseDto>>>
    {
        private IEmployeeReadOnlyRepository _readEmployeeRepository;

        public GetEmployeesQueryHandler(IEmployeeReadOnlyRepository readEmployeeRepository)
        {
            _readEmployeeRepository = readEmployeeRepository;
        }

        public async Task<Result<PageListResponse<EmployeeResponseDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employeesResult = await _readEmployeeRepository.GetEmployees(
                tenantUid: request.TenantUid,
                pageNumber: request.PageNumber,
                pageSize: request.PageSize);

            if (employeesResult.IsFailure)
            {
                return Result<PageListResponse<EmployeeResponseDto>>.FROM_ERROR(employeesResult);
            }

            return Result<PageListResponse<EmployeeResponseDto>>.OK(
                new PageListResponse<EmployeeResponseDto>
                { 
                    PageNumber = request.PageNumber,
                    Count = employeesResult.Value.Count(),
                    // find solution for total count...
                    TotalCount = 100,
                    Items = employeesResult.Value.Select(x => new EmployeeResponseDto
                    {
                        Uid = x.Uid,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        PhoneNumber = x.PhoneNumber,
                        Email = x.Email,
                        Status = x.Status,
                    }).ToList()
                });
        }
    }
}
