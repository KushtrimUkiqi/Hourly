namespace WebApp.Models.Home
{
    using Contracts.Common.Responses;
    using Contracts.Employee.Responses;

    public class TableViewModel : GeneralModel<PageListResponse<EmployeeResponseDto>>
    {
    }
}
