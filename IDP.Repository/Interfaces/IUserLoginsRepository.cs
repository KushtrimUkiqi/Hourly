namespace IDP.Repository.Interfaces
{
    using IDP.Domain.Entities;

    public interface IUserLoginsRepository : IAsyncRepository<UserLogin>
    {
        Task<UserLogin?> FindUserByExternalProviderAsync(string provider, string providerIdentityKey);
    }
}
