namespace ReadOnlyStorage.Employee.Repository
{
    using System;
    using System.Collections.Generic;
    using Contracts.Common.Results;
    using Contracts.Common.ResultTexts;
    using Contracts.Employee.Storage.Read;
    using Microsoft.EntityFrameworkCore;
    using ReadOnlyEntities.Employee;
    using ReadOnlyStorage.Employee.Context;

    public class EmployeeReadOnlyRepository : IEmployeeReadOnlyRepository
    {
        private readonly EmployeeReadOnlyDbContext _employeeDbContext;

        public EmployeeReadOnlyRepository(EmployeeReadOnlyDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<Result<Employee>> GetEmployeeByUidAsync(Guid tenantUid, Guid employeeUid)
        {
            Employee? dbEmployee = await _employeeDbContext
                .Employees
                    .Include(x => x.Tenant)
                    .Where(x => x.Uid == employeeUid 
                        && x.Tenant != null 
                        && x.Tenant.Uid == tenantUid)
                    .FirstOrDefaultAsync();

            if (dbEmployee == null)
            {
                return Result<Employee>.NOT_FOUND(ResultTexts.EMPLOYEE_NOT_FOUND);
            }

            return Result<Employee>.OK(dbEmployee);
        }

        public async Task<Result<IEnumerable<Employee>>> GetEmployees(Guid tenantUid, int pageNumber, int pageSize)
        {
            IEnumerable<Employee> employeesList = await _employeeDbContext.Employees
                        .Include(x => x.Tenant)
                    .Where(x => x.Tenant != null
                        && x.Tenant.Uid == tenantUid)
                    .Skip(pageNumber * pageSize)
                    .Take(pageSize).ToListAsync();

            if (!employeesList.Any()) 
            {
                return Result<IEnumerable<Employee>>.NOT_FOUND(ResultTexts.EMPLOYEES_NOT_FOUND);
            }

            return Result<IEnumerable<Employee>>.OK(employeesList);
        }
    }
}
