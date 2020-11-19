using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unionized.Contract.Service
{
    /// <summary>
    /// Manages devices within the current home
    /// </summary>
    public interface IHomeService
    {
        /// <summary>
        /// Get all device states within the home
        /// </summary>
        /// <returns>A list of device states within the home</returns>
        Task<List<EntityState>> GetAllStatesAsync();

        /// <summary>
        /// Get a single device's state.
        /// </summary>
        /// <param name="entityId">The ID of the device entity</param>
        /// <returns>The matching state of the device or NULL if none found</returns>
        Task<EntityState> GetStateAsync(string entityId);

        /// <summary>
        /// Set a switched entity to the current state.
        /// </summary>
        /// <param name="entityId">The ID of the device entity</param>
        /// <param name="state">The state of the entity. True = on, False = off</param>
        /// <returns>The current state of the entity after updating.</returns>
        Task<EntityState> ToggleSwitchedEntityAsync(string entityId, bool state);
    }
}
