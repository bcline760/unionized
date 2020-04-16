using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Unionized.Contract;

namespace Unionized.Contract.Repository
{
    public interface INetworkLogRepository : IUnionizedRepository<NetworkLog>
    {
        /// <summary>
        /// Get logs for a given destination address
        /// </summary>
        /// <param name="destAddr"></param>
        /// <returns></returns>
        Task<List<NetworkLog>> GetByDestinationAddressAsync(string destAddr);

        /// <summary>
        /// Get logs for a destination port
        /// </summary>
        /// <param name="port">The destination port number</param>
        /// <returns>List of logs matching the port number</returns>
        Task<List<NetworkLog>> GetByDestinationPortAsync(int port);

        /// <summary>
        /// Get logs between a date range
        /// </summary>
        /// <param name="after">Logs after a date</param>
        /// <param name="before">Logs before a date</param>
        /// <returns>List of logs matching the date range</returns>
        Task<List<NetworkLog>> GetByDateRangeAsync(DateTime? after, DateTime? before);

        /// <summary>
        /// Get network logs by the source address
        /// </summary>
        /// <param name="address"></param>
        /// <returns>List of logs matching the source address</returns>
        Task<List<NetworkLog>> GetBySourceAddressAsync(string address);

        /// <summary>
        /// Get logs by the source port
        /// </summary>
        /// <param name="port">The source port number</param>
        /// <returns>List of logs matching the port number</returns>
        Task<List<NetworkLog>> GetBySourcePortAsync(int port);
    }
}
