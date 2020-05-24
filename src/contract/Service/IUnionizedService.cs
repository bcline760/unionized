using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Unionized.Contract;

namespace Unionized.Contract.Service
{
    public interface IUnionizedService<TEntity> where TEntity : UnionizedEntity
    {
        /// <summary>
        /// Perform a soft delete on the entity. Marks inactive but persists
        /// </summary>
        /// <param name="slug">The slug of the entity to delete</param>
        /// <returns>Number of records deleted</returns>
        Task<int> DeleteAsync(string slug);

        /// <summary>
        /// Save an entity to the data store
        /// </summary>
        /// <param name="entity">The entity to save</param>
        /// <returns>Number of records saved to the data store</returns>
        Task<int> SaveAsync(TEntity entity);

        /// <summary>
        /// Gets all entities in the data store. This could be a resource intensive operation
        /// </summary>
        /// <returns>All entities of the data store</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Get an entity by its slug
        /// </summary>
        /// <param name="slug">The slug of the entity</param>
        /// <returns>The entity matching the slug</returns>
        Task<TEntity> GetAsync(string slug);
    }
}
