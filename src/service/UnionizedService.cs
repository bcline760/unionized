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

        protected IUnionizedRepository<TEntity> _repo;

        protected UnionizedService(IUnionizedRepository<TEntity> repo)
        {
            _repo = repo;
        }
        public async Task<int> SaveAsync(TEntity entity)
        {
            if (string.IsNullOrEmpty(entity.Slug))
                return await _repo.CreateAsync(entity);

            return await _repo.UpdateAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<TEntity> GetAsync(string slug)
        {
            return await _repo.GetAsync(slug);
        }
    }
}
