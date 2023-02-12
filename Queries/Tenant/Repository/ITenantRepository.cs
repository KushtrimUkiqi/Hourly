namespace Queries.Tenant.Repository
{
    using Contracts.Common.Results;
    using ReadOnlyEntities.Tenant;

    public interface ITenantReadOnlyRepository
    {
        /// <summary>
        /// Returns the tenant by uid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        Task<Result<Tenant>> GetTenantByUidAsync(Guid uid);
    }
}
