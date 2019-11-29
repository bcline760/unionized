using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Model;
using Unionized.Model.Database.Context;

using AutoMapper;

namespace Unionized.Model.Database.Repository
{
    /// <summary>
    /// Base repository for all objects fitting standard repository pattern.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public abstract class UnionizedRepository<TEntity, TModel> : IUnionizedRepository<TEntity>
        where TEntity : UnionizedEntity
        where TModel : UnionizedModel
    {
        protected IUnionizedContext Context { get; }

        protected DbSet<TModel> Set { get;  }

        protected IMapper Mapper { get; }

        protected UnionizedRepository(IUnionizedContext context, IMapper mapper)
        {
            Context = context;
            Set = Context.Context.Set<TModel>();
            Mapper = mapper;
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.Slugify();
            string slug = entity.Slug;
            var model = Mapper.Map<TModel>(entity);
            Set.Attach(model).State = EntityState.Added;

            int recordsModified = await Context.Context.SaveChangesAsync();
            return recordsModified;
        }

        public async Task<int> DeleteAsync(string slug)
        {
            var model = await GetAsync(slug);

            if (model != null)
            {
                model.Active = false;
                model.UpdatedAt = DateTime.Now;

                int recordsModified = await Context.Context.SaveChangesAsync();
                return recordsModified;
            }

            return 0;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var modelList = await Set.ToListAsync<TModel>();

            return modelList.Select(Mapper.Map<TEntity>).ToList();
        }

        public async Task<TEntity> GetAsync(string slug)
        {
            var model = await Set.FirstOrDefaultAsync(s => s.Slug == slug);
            if (model != null)
                return Mapper.Map<TEntity>(model);

            return null;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var model = Mapper.Map<TModel>(entity);
            Set.Attach(model).State = EntityState.Modified;

            int recordsModified = await Context.Context.SaveChangesAsync();
            return recordsModified;
        }
    }
}
