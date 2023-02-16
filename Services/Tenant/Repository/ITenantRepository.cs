namespace Services.Tenant.Repository
{
    using Contracts.Common.Results;

    using Entities.TenantContext.Domain;

    public interface ITenantRepository
    {
        Task<Result<Tenant>> GetTenantByUid(Guid uid);
    }
}
