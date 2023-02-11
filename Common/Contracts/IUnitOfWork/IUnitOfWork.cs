namespace IDP.Common.Contracts.IUnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Save changes asynchronously
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
