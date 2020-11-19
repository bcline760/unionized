using System;

using Unionized.Contract;
namespace Unionized.Contract.Service
{
    /// <summary>
    /// Provides basic services for LDAP authentication and retrieval.
    /// </summary>
    public interface ILdapService : IDisposable
    {
        /// <summary>
        /// Get a current directory user
        /// </summary>
        /// <param name="username">The directory user name</param>
        /// <returns></returns>
        DirectoryUser GetDirectoryUser(string username);

        /// <summary>
        /// Authenticate a user against the active directory
        /// </summary>
        /// <param name="username">Login name of the directory user</param>
        /// <param name="password">The directory user's password</param>
        /// <returns>True or false depending on the success of authentication</returns>
        bool ValidateDirectoryUser(string username, string password);
    }
}