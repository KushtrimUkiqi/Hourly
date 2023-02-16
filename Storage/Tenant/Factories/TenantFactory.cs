namespace Storage.Tenant.Factories
{
    using Contracts.Common.Results;

    public static class TenantFactory
    {
        /// <summary>
        /// Creates employee domain object from database entity
        /// </summary>
        /// <param name="dbTenant"></param>
        /// <returns>Result<Employee></returns>
        public static Result<Entities.TenantContext.Domain.Tenant> Create
            (this StorageEntities.Tenant dbTenant)
        {

            var employeeResults = dbTenant.Employees
                    .Select(x => x.Create()).ToList();

            Result employeesResultOrError = employeeResults.ReturnResult();

            if (employeesResultOrError.IsFailure)
            {
                return Result<Entities.TenantContext.Domain.Tenant>.FROM_ERROR(employeesResultOrError);
            }

            var tenantResults = Entities.TenantContext.Domain.Tenant.CreateFromStorage(
                id: dbTenant.Id,
                uid: dbTenant.Uid,
                createdOn: dbTenant.CreatedOn,
                deletedOn: dbTenant.DeletedOn,
                name: dbTenant.Name,
                address: dbTenant.Address,
                website: dbTenant.WebSite,
                employees: employeeResults.Select(x => x.Value).ToList());

            return tenantResults;
        }

        /// <summary>
        /// Creates employee domain objects from database entities
        /// </summary>
        /// <param name="dbTenants"></param>
        /// <returns>IEnumerable<Result<Employee>></returns>
        public static IEnumerable<Result<Entities.TenantContext.Domain.Tenant>> Create
            (this IEnumerable<StorageEntities.Tenant> dbTenants)
        {
            List<Result<Entities.TenantContext.Domain.Tenant>> tenantsResult = new(dbTenants.Count());

            foreach (var dbTenant in dbTenants)
            {
                tenantsResult.Add(dbTenant.Create());
            }

            return tenantsResult;
        }
    }
}
