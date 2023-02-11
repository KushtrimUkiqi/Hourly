namespace IDP.Repository
{
    using System.Threading.Tasks;

    using IDP.Repository.DbContext;
    using IDP.Common.Contracts.IUnitOfWork;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityDbContext _identityDbContext;

        public UnitOfWork(IdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _identityDbContext.SaveChangesAsync();
        }
    }
}
