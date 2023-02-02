namespace WebApp.Models
{
    using Contracts.Common.Responses;
    using Contracts.Employee.Responses;

    public class IndexModel
    {
        public PageListResponse<EmployeeResponseDto>? Employees { get; set; } = null;

        public string? Error { get; set; } = null;
    }
}
