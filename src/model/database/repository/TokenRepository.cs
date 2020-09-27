using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Driver;

using AutoMapper;
using Unionized.Contract;
using Unionized.Contract.Repository;

namespace Unionized.Model.Database.Repository
{
    internal sealed class TokenRepository : UnionizedRepository<UserToken, UserTokenModel>, ITokenRepository
    {
        public TokenRepository(IMongoDatabase context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<UserToken>> GetByUserAsync(string userSlug)
        {
            var filter = Builders<UserTokenModel>.Filter.Eq("generated_by", userSlug);
            var result = await Collection.FindAsync(filter);

            List<UserToken> tokens = new List<UserToken>();
            if (result.Any())
            {
                var docs = await result.ToListAsync();
                tokens.AddRange(Mapper.Map<List<UserToken>>(docs));
            }

            return tokens;
        }
    }
}
