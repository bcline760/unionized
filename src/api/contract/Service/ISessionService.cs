using System.Threading.Tasks;

using Unionized.Contract;

namespace Unionized.Contract.Service
{
    /// <summary>
    /// Defines how to perform authentication and logon services to the System.
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Log on a user to the system
        /// </summary>
        /// <param name="request">The user's credentials</param>
        /// <returns>A response containing the result of the logon operation</returns>
        Task<LogonResponse> AuthenticateAsync(LogonRequest request);

        /// <summary>
        /// Log the user out of the system by disabling its authentication token
        /// </summary>
        /// <param name="username">The authenticated user</param>
        /// <param name="token">The token to eventually disable</param>
        Task LogoutAsync(string username, string token);

        /// <summary>
        /// Validates a user's token. Destroys invalid tokens
        /// </summary>
        /// <param name="token">The token text</param>
        /// <param name="username">The user holding the token</param>
        /// <returns>Boolean value indicating validity of token</returns>
        Task<bool> ValidateTokenAsync(string token, string username);
    }
}
