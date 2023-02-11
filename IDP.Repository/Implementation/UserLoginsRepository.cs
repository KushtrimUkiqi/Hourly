namespace IDP.Repository.Implementation
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using IDP.Domain.Entities;
    using IDP.Repository.DbContext;
    using IDP.Repository.Interfaces;

    public class UserLoginsRepository : IUserLoginsRepository
    {
        private readonly IdentityDbContext _identityDbContext;

        public UserLoginsRepository(IdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public async Task<UserLogin?> FindUserByExternalProviderAsync(string provider, string providerIdentityKey)
        {
            UserLogin? userLogin = await _identityDbContext.UserLogins.Include(ul => ul.User)
               .FirstOrDefaultAsync(ul => ul.Provider == provider
               && ul.ProviderIdentityKey == providerIdentityKey);

            return userLogin;
        }

        public virtual async Task<UserLogin?> GetByIdAsync(Guid id)
        {
            UserLogin? userLogin = await _identityDbContext.Set<UserLogin>().FindAsync(id);
            return userLogin;
        }

        public async Task<IReadOnlyList<UserLogin>> ListAllAsync()
        {
            return await _identityDbContext.Set<UserLogin>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<UserLogin>> GetPagedReponseAsync(int page, int size)
        {
            return await _identityDbContext.Set<UserLogin>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<UserLogin> AddAsync(UserLogin entity)
        {
            await _identityDbContext.Set<UserLogin>().AddAsync(entity);

            return entity;
        }

        public async Task UpdateAsync(UserLogin entity)
        {
            _identityDbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(UserLogin entity)
        {
            _identityDbContext.Set<UserLogin>().Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _identityDbContext.SaveChangesAsync();
        }
    }
}
