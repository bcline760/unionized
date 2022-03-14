using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unionized.Contract.Repository
{
    /// <summary>
    /// Repository for handling signin tokens
    /// </summary>
    public interface ITokenRepository : IUnionizedRepository<UserToken>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSlug"></param>
        /// <returns></returns>
        Task<List<UserToken>> GetByUserAsync(string userSlug);
    }
}
