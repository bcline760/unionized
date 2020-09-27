using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Contract.Service;

namespace Unionized.Service
{
    public abstract class UnionizedService<TEntity> : IUnionizedService<TEntity>
        where TEntity : UnionizedEntity
    {
        /// <summary>
        /// 
        /// </summary>
        protected virtual IUnionizedRepository<TEntity> Repository { get; set; }

        protected UnionizedService(IUnionizedRepository<TEntity> repo)
        {
            Repository = repo;
        }

        public async Task DeleteAsync(string slug)
        {
            await Repository.DeleteAsync(slug);
        }

        public async Task SaveAsync(TEntity entity)
        {
            await Repository.SaveAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public async Task<TEntity> GetAsync(string slug)
        {
            return await Repository.GetAsync(slug);
        }
    }
}
