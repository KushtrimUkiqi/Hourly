namespace Storage.Tenant.Repositories
{
    using System;
    using System.Threading.Tasks;

    using Services.Tenant.Repository;
    using Microsoft.EntityFrameworkCore;

    using Contracts.Common.Results;
    using Contracts.Common.ResultTexts;

    using Entities.TenantContext.Domain;

    using Storage.Tenant.Context;
    using Storage.Tenant.Factories;

    public class TenantRepository : ITenantRepository
    {
        private readonly TenantDbContext _tenantDbContext;

        public TenantRepository(TenantDbContext tenantDbContext)
        {
            _tenantDbContext = tenantDbContext;
        }

        public async Task<Result<Tenant>> GetTenantByUid(Guid uid)
        {
            StorageEntities.Tenant? dbTenant = await _tenantDbContext.Tenants
                    .Where(x => x.Uid == uid)
                        .FirstOrDefaultAsync();

            if (dbTenant == null)
            {
                return Result<Tenant>.NOT_FOUND(ResultTexts.TENANT_NOT_FOUND);
            }

            return dbTenant.Create();
        }
    }
}
