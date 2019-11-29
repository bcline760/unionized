using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unionized.Contract.Repository
{
    public interface IRoleRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<AppRole>> GetAllRoles();

        /// <summary>
        /// Get roles defined by a security group
        /// </summary>
        /// <param name="securityGroup"></param>
        /// <returns></returns>
        Task<AppRole> GetBySecurityGroup(string securityGroup);

        /// <summary>
        /// Create a new role in the database
        /// </summary>
        /// <param name="securityGroup">The AD Security group matching the role</param>
        /// <param name="role">The assigned role</param>
        /// <returns>A new application role object inserted to the database</returns>
        Task<AppRole> CreateRole(string securityGroup, RoleType role);
    }
}
