namespace Storage.Employee.Repositories
{
    using Services.Employee.Repository;
    using Entities.EmployeeContext.Domain;
    using System.Threading.Tasks;
    using Contracts.Common.Results;
    using Storage.Employee.Context;
    using System;
    using Microsoft.EntityFrameworkCore;
    using Contracts.Common.ResultTexts;
    using Storage.Employee.Factories;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<Result<Employee>> GetEmployeeByUidAsync(Guid tenantUid, Guid employeeUid)
        {
            StorageEntities.Employee? dbEmployee  = await _employeeDbContext.Employees
                                .Include(x => x.Tenant)
                                .Where(x => x.Uid == employeeUid 
                                    && x.Tenant != null 
                                    && x.Tenant.Uid == tenantUid)
                                .FirstOrDefaultAsync();

            if (dbEmployee == null)
            {
                return Result<Employee>.NOT_FOUND(ResultTexts.EMPLOYEE_NOT_FOUND);
            }

            return dbEmployee.Create();
        }

        public async Task<Result<Tenant>> GetTenantByUidAsync(Guid tenantUid)
        {
            StorageEntities.Tenant? dbTenant = await _employeeDbContext.Set<StorageEntities.Tenant>().FirstOrDefaultAsync(x => x.Uid == tenantUid);

            if (dbTenant == null)
            {
                return Result<Tenant>.NOT_FOUND(ResultTexts.TENANT_NOT_FOUND);
            }

            return dbTenant.Create();
        }

        public async Task<Result> AddAsync(Employee employee)
        {
            var dbEmployeeResult = employee.Create();

            if(dbEmployeeResult.IsFailure)
            {
                return dbEmployeeResult;
            }

            await _employeeDbContext.Set<StorageEntities.Employee>().AddAsync(dbEmployeeResult.Value);

            return Result.OK();
        }


        public async Task<Result> UpdateAsync(Employee employee)
        {
            var dbEmployeeResult = employee.Create();

            if (dbEmployeeResult.IsFailure)
            {
                return dbEmployeeResult;
            }

            StorageEntities.Employee? dbExistingEmployee = await _employeeDbContext.Set<StorageEntities.Employee>().FirstOrDefaultAsync(x => x.Id == employee.Id);

            if(dbExistingEmployee == null || dbEmployeeResult.Value == null)
            {
                return Result.NOT_FOUND();
            }

            _employeeDbContext.Entry(dbExistingEmployee).CurrentValues.SetValues(dbEmployeeResult.Value);
            _employeeDbContext.Entry(dbEmployeeResult.Value).State = EntityState.Detached;

            return Result.OK();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _employeeDbContext.Set<Employee>().Remove(employee);
        }

        public async Task<Result> SaveChangesAsync()
        {
            await _employeeDbContext.SaveChangesAsync();

            return Result.OK();
        }
    }
}
