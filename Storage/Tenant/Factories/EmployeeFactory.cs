namespace Storage.Tenant.Factories
{
    using Contracts.Common.Results;

    public static class EmployeeFactory
    {
        /// <summary>
        /// Creates employee domain object from database entity
        /// </summary>
        /// <param name="dbEmployee"></param>
        /// <returns>Result<Employee></returns>
        public static Result<Entities.TenantContext.Domain.Employee> Create
            (this StorageEntities.Employee dbEmployee)
        {
            var employeeResult = Entities.TenantContext.Domain.Employee.CreateFromStorage(
                id: dbEmployee.Id,
                uid: dbEmployee.Uid,
                createdOn: dbEmployee.CreatedOn,
                deletedOn: dbEmployee.DeletedOn);

            return employeeResult;
        }

        /// <summary>
        /// Creates employee domain objects from database entities
        /// </summary>
        /// <param name="dbEmployees"></param>
        /// <returns>IEnumerable<Result<Employee>></returns>
        public static IEnumerable<Result<Entities.TenantContext.Domain.Employee>> Create
            (this IEnumerable<StorageEntities.Employee> dbEmployees)
        {
            List<Result<Entities.TenantContext.Domain.Employee>> employeesResult = new(dbEmployees.Count());

            foreach (var dbEmployee in dbEmployees)
            {
                employeesResult.Add(dbEmployee.Create());
            }

            return employeesResult;
        }
    }
}
