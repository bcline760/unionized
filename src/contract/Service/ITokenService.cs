using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unionized.Contract.Service
{
    /// <summary>
    /// Defines operations for authentication tokens
    /// </summary>
    public interface ITokenService : IUnionizedService<UserToken>
    {
        /// <summary>
        /// Generate a persistent authentication token. This is mainly used for automated operations
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UserToken> GeneratePersistentToken(TokenRequest request);
    }
}
