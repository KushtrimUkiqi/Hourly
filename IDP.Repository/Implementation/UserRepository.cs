namespace IDP.Repository.Implementation
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using IDP.Domain.Entities;
    using IDP.Repository.DbContext;
    using IDP.Repository.Interfaces;

    using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _identityDbContext;

        public UserRepository(IdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public virtual async Task<User?> GetByIdAsync(Guid id)
        {
            User? user = await _identityDbContext.Set<User>().FindAsync(id);
            return user;
        }

        public async Task<IReadOnlyList<User>> ListAllAsync()
        {
            return await _identityDbContext.Set<User>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<User>> GetPagedReponseAsync(int page, int size)
        {
            return await _identityDbContext.Set<User>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<User> AddAsync(User entity)
        {
            entity.CreatedOn= DateTime.Now;
            await _identityDbContext.Set<User>().AddAsync(entity);

            return entity;
        }

        public async Task UpdateAsync(User entity)
        {
            _identityDbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(User entity)
        {
            _identityDbContext.Set<User>().Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _identityDbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserBySubjectAsync(string subject)
        {
            return await _identityDbContext.Users
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                        .ThenInclude(x => x.Permissions)
                .FirstOrDefaultAsync(u => u.Subject == subject);
        }

        public async Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(string subject)
        {
            return await _identityDbContext.UserClaims.Where(u =>
                u.User.Subject == subject).ToListAsync();
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            User? user = await _identityDbContext.Users
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                        .ThenInclude(x => x.Permissions)
                .FirstOrDefaultAsync(u => u.UserName == userName);

            return user;
        }

        public async Task<bool> IsUserEmailUniqueAsync(string email)
        {
            string? userEmail = await _identityDbContext.Users
                .Where(x => x.Email == email)
                .Select(x => x.Email)
                .FirstOrDefaultAsync();

            return userEmail == null;
        }

        public async Task<bool> IsUserUserNameUniqueAsync(string userName)
        {
            string? userUserName = await _identityDbContext.Users
                .Where(x => x.UserName == userName)
                .Select(x => x.UserName)
                .FirstOrDefaultAsync();

            return userUserName == null;
        }

        public async Task<User?> FindUserByActiveSecurityCode(string securityCode, DateTime dateTime)
        {
            User? user = await _identityDbContext.Users.FirstOrDefaultAsync(u =>
                u.SecurityCode == securityCode &&
                u.SecurityCodeExpirationDate >= dateTime);

            return user;
        }
    }
}
