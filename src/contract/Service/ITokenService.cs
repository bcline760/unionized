﻿using System;
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
        Task<UserToken> GenerateAuthenticationTokenAsync(TokenRequest request);

        /// <summary>
        /// Get a token by the value and its user
        /// </summary>
        /// <param name="user">The user to look up</param>
        /// <param name="token">The stored token to look up</param>
        /// <returns>The user token matching the user and token text</returns>
        Task<UserToken> GetTokenByUserAndTokenAsync(string user, string token);
    }
}
