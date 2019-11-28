using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Unionized.Contract;

namespace Unionized.Contract.Repository
{
    public interface IUnionizedRepository<TEntity> where TEntity : UnionizedEntity
    {
        /// <summary>
        /// Insert a new record to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateAsync(TEntity entity);

        /// <summary>
        /// Returns the entire table. This could taks the database server, use with caution
        /// </summary>
        /// <returns>All records in the given table</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(string slug);

        /// <summary>
        /// Update a record inside the database
        /// </summary>
        /// <param name="entity">The entity record to update</param>
        /// <returns>Number of rows modified</returns>
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete's a record from the database by marking it inactive. Record persists
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Number of rows modified</returns>
        Task<int> DeleteAsync(string slug);
    }
}
