namespace Services.Employee.Repository
{
    using Contracts.Common.Results;
    using Entities.EmployeeContext.Domain;

    public interface IEmployeeRepository
    {
        /// <summary>
        /// Returns employee details for employee uid
        /// </summary>
        /// <param name="employeeUid"></param>
        /// <returns></returns> 
        Task<Result<Employee>> GetEmployeeByUidAsync(Guid employeeUid);

        /// <summary>
        /// Adds a new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<Result> AddAsync(Employee employee);

        /// <summary>
        /// Deletes employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task DeleteAsync(Employee employee);

        /// <summary>
        /// Saves all changes
        /// </summary>
        /// <returns></returns>
        Task<Result> SaveChangesAsync();
    }
}
