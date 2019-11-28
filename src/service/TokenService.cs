using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Contract.Service;

namespace Unionized.Service
{
    public class TokenService : UnionizedService<UserToken>, ITokenService
    {
        public TokenService(ITokenRepository repository) : base(repository)
        {

        }
        public Task<UserToken> GeneratePersistentToken(TokenRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
