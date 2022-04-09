using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Unionized.Contract;

namespace Unionized.Interface.Service
{
    public interface IEntityService
    {
        /// <summary>
        /// Get the current state of the entity
        /// </summary>
        /// <param name="entity_id">The ID of the entity</param>
        /// <returns>The current entity's state</returns>
        Task<EntityState> GetStateAsync(string entity_id);
    }
}
