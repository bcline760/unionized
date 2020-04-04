using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Model.Database.Context;

namespace Unionized.Model.Database.Repository
{
    internal sealed class TokenRepository : UnionizedRepository<UserToken, UserTokenModel>, ITokenRepository
    {
        public TokenRepository(IUnionizedContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<UserToken>> GetByUserAsync(string userSlug)
        {
            var tokenList = await (
                from t in Set
                where t.GeneratedBy == userSlug
                select Mapper.Map<UserToken>(t)
                ).ToListAsync();

            return tokenList;
        }
    }
}
