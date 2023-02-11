namespace IDP.Services.Interfaces
{
    using IDP.Domain.Entities;
    using System.Security.Claims;

    public interface ILocalUserService
    {

        public Task<User> FindUserByExternalProviderAsync(string provider, string providerIdentityKey);

        public User AutoProvisionUser(string provider,
            string providerIdentityKey,
            IEnumerable<Claim> claims);

        Task<bool> ValidateCredentialsAsync(
             string userName,
             string password);

        Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(
            string subject);

        Task<User> GetUserByUserNameAsync(
            string userName);

        Task<User> GetUserBySubjectAsync(
            string subject);

        void AddUser
            (User userToAdd,
            string password);

        Task<bool> AddUserSecret(string subject, string name, string secret);

        Task<bool> IsUserActive(
            string subject);

        Task<bool> ActivateUserAsync(string securityCode);

        //Task<bool> SaveChangesAsync();
    }
}
