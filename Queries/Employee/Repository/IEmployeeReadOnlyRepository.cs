namespace Contracts.Employee.Storage.Read
{
    using Contracts.Common.Results;
    using ReadOnlyStorage.Employee.Entities;

    public interface IEmployeeReadOnlyRepository
    {
        /// <summary>
        /// Returns employee details for employee uid
        /// </summary>
        /// <param name="employeeUid"></param>
        /// <returns></returns>
        public Result<Employee> GetEmployeeByUid(Guid employeeUid);
    }
}
