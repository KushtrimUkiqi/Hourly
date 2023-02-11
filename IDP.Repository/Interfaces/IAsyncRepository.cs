namespace IDP.Repository.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore;

    public interface IAsyncRepository<T> where T : class
    {
        /// <summary>
        /// Returns the entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Get all entities, expensive operation do not use it in normal cases
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Get entitys as pageable list
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);

        Task SaveChangesAsync();
    }
}
