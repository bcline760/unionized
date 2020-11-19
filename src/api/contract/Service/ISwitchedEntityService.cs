using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Unionized.Contract.Service
{
    /// <summary>
    /// Supports switched entities
    /// </summary>
    public interface ISwitchedEntityService : IEntityService
    {
        /// <summary>
        /// Turn a switched entity on
        /// </summary>
        /// <param name="switch_id">The ID of the entity to turn on</param>
        /// <returns>The state of the entity</returns>
        Task<EntityState> TurnOnAsync(string switch_id);

        /// <summary>
        /// Turn off a switched entity
        /// </summary>
        /// <param name="switch_id">The ID of the entity to turn off</param>
        /// <returns>The state of the entity</returns>
        Task<EntityState> TurnOffAsync(string switch_id);
    }
}
