using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using MongoDB.Driver;

using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Model;

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
        protected IMongoCollection<TModel> Collection { get; }

        protected IMapper Mapper { get; }

        protected UnionizedRepository(IMongoDatabase context, IMapper mapper)
        {
            string collectionName = GetCollectionName();
            Collection = context.GetCollection<TModel>(collectionName);
            Mapper = mapper;
        }

        public virtual async Task DeleteAsync(string slug)
        {
            var record = await GetAsync(slug);

            if (record != null)
            {
                record.Active = false;
                record.UpdatedAt = DateTime.Now;

                await SaveAsync(record);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            List<TEntity> entities = new List<TEntity>();
            var filter = Builders<TModel>.Filter.Empty;
            using (var collection = await Collection.FindAsync(filter))
            {
                var models = await collection.ToListAsync();
                entities.AddRange(Mapper.Map<List<TEntity>>(models));
            }

            return entities;
        }

        public virtual async Task<TEntity> GetAsync(string slug)
        {
            var filter = Builders<TModel>.Filter.Eq("slug", slug);
            using (var result = await Collection.FindAsync(filter))
            {
                var doc = await result.FirstOrDefaultAsync();
                var map = Mapper.Map<TEntity>(doc);

                return map;
            }
        }

        public virtual async Task SaveAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrEmpty(entity.Slug))
                entity.Slugify();

            var model = Mapper.Map<TModel>(entity);
            var filter = Builders<TModel>.Filter.Eq("slug", model.Slug);
            var result = await Collection.ReplaceOneAsync(filter, model, new ReplaceOptions { IsUpsert = true });
        }

        /// <summary>
        /// Get the name of the collection based off the model. Will appropriatly pluralize
        /// </summary>
        /// <typeparam name="TModel">The type of the model to use</typeparam>
        /// <returns>The name of the collection</returns>
        protected string GetCollectionName()
        {
            Type modelType = typeof(TModel);
            string modelName = modelType.Name.Replace("Model", string.Empty);
            string collectionName = string.Empty;
            char endingCharacter = modelName[modelName.Length - 1];

            //Be smart about English
            if (char.ToLowerInvariant(endingCharacter) == 'y')
            {
                char nextChar = modelName[modelName.Length - 2];
                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                if (vowels.Any(v => v == nextChar))
                    collectionName = string.Concat(modelName, 's'); //bays, toys, keys
                else
                    collectionName = string.Concat(modelName.Substring(0, modelName.Length - 2), "ies"); //histories, flies, countries, etc.
            }
            else if (char.ToLowerInvariant(endingCharacter) == 'o') //Gonna have the odd case here...pianoes
            {
                collectionName = string.Concat(modelName, "es");
            }
            else
                collectionName = string.Concat(modelName, 's'); //Bows, Arrows

            Regex s_seperateWordRegex =
                            new Regex(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            return collectionName.ToLowerInvariant();
        }
    }
}
