namespace Storage.Employee.Factories
{
    using Contracts.Common.Results;

    public static class TenantFactory
    {
        /// <summary>
        /// Creates employee domain object from database entity
        /// </summary>
        /// <param name="dbTenant"></param>
        /// <returns>Result<Employee></returns>
        public static Result<Entities.EmployeeContext.Domain.Tenant> Create
            (this StorageEntities.Tenant dbTenant)
        {

            var tenantResults = Entities.EmployeeContext.Domain.Tenant.CreateFromStorage(
                id: dbTenant.Id,
                uid: dbTenant.Uid,
                createdOn: dbTenant.CreatedOn,
                deletedOn: dbTenant.DeletedOn);

            return tenantResults;
        }
    }
}
