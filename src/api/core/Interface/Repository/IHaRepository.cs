using System.Collections.Generic;
using System.Threading.Tasks;

using Unionized.Contract;

namespace Unionized.Interface.Repository
{
    /// <summary>
    /// Base definition for Home Assistant data access
    /// </summary>
    /// <typeparam name="TAttributes">Kind of entity attributes to be used</typeparam>
    public interface IHaRepository
    {
        /// <summary>
        /// Call a service method
        /// </summary>
        /// <param name="entityId">The ID of the entity</param>
        /// <param name="domain">The particular service domain</param>
        /// <param name="service">The type of service to call</param>
        /// <returns>The state of the entity after the service call</returns>
        Task<EntityState> CallServiceAsync(string entityId, ServiceDomain domain, string service);
        /// <summary>
        /// Get the state of all the entities
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, string>> GetAllEntityStatesAsync();
        /// <summary>
        /// Gets the current state of the entity
        /// </summary>
        /// <param name="entityId">ID of the entity to retrieve</param>
        /// <returns>The state of the entity</returns>
        Task<EntityState> GetEntityStateAsync(string entityId);
        /// <summary>
        /// Sets the state of the entity
        /// </summary>
        /// <param name="entityId">The ID of the Home Assistant entity</param>
        /// <param name="state">The valid state to set for the given entity</param>
        /// <param name="attributes">A serialized JSON object of attribute definitions. This is optional.</param>
        /// <returns></returns>
        Task<EntityState> SetEntityStateAsync(string entityId, string state, string attributes = null);
    }
}