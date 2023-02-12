namespace ReadOnlyStorage.Tenant.Repository
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts.Common.Results;
    using Contracts.Common.ResultTexts;

    using Queries.Tenant.Repository;
    using ReadOnlyEntities.Tenant;
    using ReadOnlyStorage.Tenant.Context;

    public class TenantReadOnlyRepository : ITenantReadOnlyRepository
    {
        private readonly TenantReadOnlyDbContext _tenantReadOnlyDbContext;

        public TenantReadOnlyRepository(TenantReadOnlyDbContext tenantReadOnlyDbContext)
        {
            _tenantReadOnlyDbContext = tenantReadOnlyDbContext;
        }

        public async Task<Result<Tenant>> GetTenantByUidAsync(Guid uid)
        {
            Tenant? dbTenant = await _tenantReadOnlyDbContext.Tenants
                .Where(x => x.Uid == uid)
                .FirstOrDefaultAsync();

            if (dbTenant == null)
            {
                return Result<Tenant>.NOT_FOUND(ResultTexts.TENANT_NOT_FOUND);
            }

            return Result<Tenant>.OK(dbTenant);
        }
    }
}
