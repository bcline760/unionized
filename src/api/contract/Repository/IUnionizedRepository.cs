using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Unionized.Contract;

namespace Unionized.Contract.Repository
{
    public interface IUnionizedRepository<TEntity> where TEntity : UnionizedEntity
    {
        /// <summary>
        /// Returns all collections from the database. This could be an expensive procedure. Handle with care
        /// </summary>
        /// <returns>All records in the given table</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets a single document from the database
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(string slug);

        /// <summary>
        /// Saves a document inside the database
        /// </summary>
        /// <param name="entity">The entity record to update</param>
        /// <returns>Number of rows modified</returns>
        Task SaveAsync(TEntity entity);

        /// <summary>
        /// Delete's a record from the database by marking it inactive. Record persists
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Number of rows modified</returns>
        Task DeleteAsync(string slug);
    }
}
