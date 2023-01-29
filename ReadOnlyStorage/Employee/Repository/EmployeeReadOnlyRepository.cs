namespace ReadOnlyStorage.Employee.Repository
{
    using System;

    using Contracts.Common.Results;
    using Contracts.Employee.Storage.Read;

    using ReadOnlyStorage.Employee.Context;
    using ReadOnlyStorage.Employee.Entities;

    public class EmployeeReadOnlyRepository : IEmployeeReadOnlyRepository
    {
        private readonly EmployeeReadOnlyDbContext _employeeDbContext;

        public EmployeeReadOnlyRepository(EmployeeReadOnlyDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public Result<Employee> GetEmployeeByUid(Guid employeeUid)
        {
            Employee? dbEmployee = _employeeDbContext.employees.Where(x => x.Uid == employeeUid).FirstOrDefault();

            if (dbEmployee == null)
            {
                return Result<Employee>.NOT_FOUND("Employee is not found");
            }

            return Result<Employee>.OK(dbEmployee);
        }
    }
}
