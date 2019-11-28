using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Unionized.Contract;

namespace Unionized.Contract.Service
{
    public interface IUnionizedService<TEntity> where TEntity : UnionizedEntity
    {
        Task<int> SaveAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(string slug);
    }
}
