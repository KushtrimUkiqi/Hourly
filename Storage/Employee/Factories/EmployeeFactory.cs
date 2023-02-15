namespace Storage.Employee.Factories
{
    using Contracts.Common.Results;

    /// <summary>
    /// Factory method which transleates employee domain objects to storage entites and backwards
    /// </summary>
    public static class EmployeeFactory
    {
        /// <summary>
        /// Creates employee domain object from database entity
        /// </summary>
        /// <param name="dbEmployee"></param>
        /// <returns>Result<Employee></returns>
        public static Result<Entities.EmployeeContext.Domain.Employee> Create 
            (this StorageEntities.Employee dbEmployee)
        {
            var employeeResult = Entities.EmployeeContext.Domain.Employee.CreateFromStorage(
                id: dbEmployee.Id,
                uid: dbEmployee.Uid,
                createdOn: dbEmployee.CreatedOn,
                deletedOn: dbEmployee.DeletedOn,
                firstName: dbEmployee.FirstName,
                lastName: dbEmployee.LastName,
                email: dbEmployee.Email,
                position: "",
                phoneNumber: dbEmployee.PhoneNumber,
                status: dbEmployee.Status,
                tenantId: dbEmployee.TenantId);

            return employeeResult;
        }

        /// <summary>
        /// Creates employee domain objects from database entities
        /// </summary>
        /// <param name="dbEmployees"></param>
        /// <returns>IEnumerable<Result<Employee>></returns>
        public static IEnumerable<Result<Entities.EmployeeContext.Domain.Employee>> Create
            (this IEnumerable<StorageEntities.Employee> dbEmployees)
        {
            List<Result<Entities.EmployeeContext.Domain.Employee>> employeesResult = new(dbEmployees.Count());

            foreach(var dbEmployee in dbEmployees)
            {
                employeesResult.Add(dbEmployee.Create());
            }

            return employeesResult;
        }

        /// <summary>
        /// Creates employee entity from employee domain object
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Result<StorageEntities.Employee></returns>
        public static Result<StorageEntities.Employee> Create 
            (this Entities.EmployeeContext.Domain.Employee employee)
        {
            StorageEntities.Employee dbEmployee = new()
            {
                Id = employee.Id,
                Uid = employee.Uid,
                CreatedOn = employee.CreatedOn,
                DeletedOn = employee.DeletedOn,
                FirstName = employee.FirstName.Value,
                LastName = employee.LastName.Value,
                Email = employee.EmailAddress.Value,
                PhoneNumber = employee.PhoneNumber.Value,
                Status = employee.Status,
                TenantId = employee.TenantId
            };

            return Result<StorageEntities.Employee>.OK(dbEmployee);
        }

        /// <summary>
        /// Creates employee entities objects from employee domain objects
        /// </summary>
        /// <param name="employees"></param>
        /// <returns>IEnumerable<Result<Employee>></returns>
        public static IEnumerable<Result<StorageEntities.Employee>> Create
            (this IEnumerable<Entities.EmployeeContext.Domain.Employee> employees)
        {
            List<Result<StorageEntities.Employee>> dbEmployeesResult = new(employees.Count());

            foreach (var employee in employees)
            {
               dbEmployeesResult.Add (employee.Create());
            }

            return dbEmployeesResult;
        }
    }
}
