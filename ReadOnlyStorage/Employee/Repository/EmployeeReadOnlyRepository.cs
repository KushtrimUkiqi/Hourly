namespace ReadOnlyStorage.Employee.Repository
{
    using System;
    using System.Collections.Generic;
    using Contracts.Common.Results;
    using Contracts.Common.ResultTexts;
    using Contracts.Employee.Storage.Read;
    using Microsoft.EntityFrameworkCore;
    using ReadOnlyStorage.Employee.Context;
    using ReadOnlyStorage.Employee.Entities;

    public class EmployeeReadOnlyRepository : IEmployeeReadOnlyRepository
    {
        private readonly EmployeeReadOnlyDbContext _employeeDbContext;

        public EmployeeReadOnlyRepository(EmployeeReadOnlyDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<Result<Employee>> GetEmployeeByUidAsync(Guid employeeUid)
        {
            Employee? dbEmployee = await _employeeDbContext.Employees.Where(x => x.Uid == employeeUid).FirstOrDefaultAsync();

            if (dbEmployee == null)
            {
                return Result<Employee>.NOT_FOUND(ResultTexts.EMPLOYEE_NOT_FOUND);
            }

            return Result<Employee>.OK(dbEmployee);
        }

        public async Task<Result<IEnumerable<Employee>>> GetEmployees(int pageNumber, int pageSize)
        {
            IEnumerable<Employee> employeesList = await _employeeDbContext.Employees
                .Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();

            if (!employeesList.Any()) 
            {
                return Result<IEnumerable<Employee>>.NOT_FOUND(ResultTexts.EMPLOYEES_NOT_FOUND);
            }

            return Result<IEnumerable<Employee>>.OK(employeesList);
        }
    }
}
