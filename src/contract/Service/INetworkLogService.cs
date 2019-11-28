using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Unionized.Contract;

namespace Unionized.Contract.Service
{
    public interface INetworkLogService : IUnionizedService<NetworkLog>
    {
        /// <summary>
        /// Parses and saves a log from the Ubiquiti USG Network gateway
        /// </summary>
        /// <param name="logText">The raw log text coming from the gateway</param>
        /// <returns>The number of rows returned</returns>
        Task<int> SaveLog(string logText);
    }
}
