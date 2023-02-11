namespace IDP.Repository.Interfaces
{
    using IDP.Domain.Entities;
    using System.Security.Permissions;

    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User?> GetUserBySubjectAsync(string subject);

        Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(string subject);

        Task<User?> GetUserByUserNameAsync(string userName);

        Task<bool> IsUserEmailUniqueAsync(string email);

        Task<bool> IsUserUserNameUniqueAsync(string userName);

        Task<User?> FindUserByActiveSecurityCode(string securityCode, DateTime dateTime);
    }
}
