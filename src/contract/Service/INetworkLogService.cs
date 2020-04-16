using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Unionized.Contract;

namespace Unionized.Contract.Service
{
    public interface INetworkLogService : IUnionizedService<NetworkLog>
    {
        /// <summary>
        /// Gets logs by the date. One parameter is required
        /// </summary>
        /// <param name="after">Logs after this date</param>
        /// <param name="before">Logs before this date</param>
        /// <returns>Logs matching the date window</returns>
        Task<List<NetworkLog>> GetLogsByDate(DateTime? after, DateTime? before);

        /// <summary>
        /// Get logs by the port number. At least one value is required
        /// </summary>
        /// <param name="sourcePort"></param>
        /// <param name="destinationPort"></param>
        /// <returns></returns>
        Task<List<NetworkLog>> GetLogsByPort(int? sourcePort, int? destinationPort);

        /// <summary>
        /// Get logs by either the source or destination IP addresses
        /// </summary>
        /// <param name="srcAddr">(Optional) The source IP address</param>
        /// <param name="destAddr">(Optional) The destination IP address</param>
        /// <returns></returns>
        Task<List<NetworkLog>> GetLogsByAddress(string srcAddr, string destAddr);

        /// <summary>
        /// Parses and saves a log from the Ubiquiti USG Network gateway
        /// </summary>
        /// <param name="logText">The raw log text coming from the gateway</param>
        /// <returns>The number of rows returned</returns>
        Task<int> SaveLog(string logText);
    }
}
