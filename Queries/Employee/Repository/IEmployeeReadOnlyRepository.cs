namespace Contracts.Employee.Storage.Read
{
    using Contracts.Common.Results;
    using ReadOnlyEntities.Employee;

    public interface IEmployeeReadOnlyRepository
    {
        /// <summary>
        /// Returns employee details for employee uid
        /// </summary>
        /// <param name="employeeUid"></param>
        /// <returns></returns>
        Task<Result<Employee>> GetEmployeeByUidAsync(Guid tenantUid, Guid employeeUid);

        /// <summary>
        /// Returns all employees as pageable
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<Result<IEnumerable<Employee>>> GetEmployees(Guid tenantUid, int pageNumber, int pageSize);
    }
}
