using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Unionized.Contract.Service
{
    /// <summary>
    /// Defines operations for authentication tokens
    /// </summary>
    public interface ITokenService : IUnionizedService<UserToken>
    {
        /// <summary>
        /// Invalidates all user token
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task InvalidateUserTokens(string username);

        /// <summary>
        /// Generate a persistent authentication token. This is mainly used for automated operations
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UserToken> GenerateAuthenticationTokenAsync(TokenRequest request);

        /// <summary>
        /// Get a token by the value and its user
        /// </summary>
        /// <param name="user">The user to look up</param>
        /// <param name="token">The stored token to look up</param>
        /// <returns>The user token matching the user and token text</returns>
        Task<UserToken> GetTokenByUserAndTokenAsync(string user, string token);

        /// <summary>
        /// Validate a JWT
        /// </summary>
        /// <param name="token">The signed JWT to validate</param>
        /// <param name="audience">The audience of the JWT</param>
        /// <param name="issuer">The issuer of the JWT</param>
        /// <returns>The claims in the token or null if invalid token</returns>
        ClaimsPrincipal ValidateToken(string token, string audience, string issuer);
    }
}
