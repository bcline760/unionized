using System.Collections.Generic;
using System.Threading.Tasks;
using Unionized.Contract;

namespace Unionized.Contract.Service
{
    public interface IMonitoredServerService : IUnionizedService<MonitoredServer>
    {
        Task<List<MonitoredServer>> CheckServers();
    }
}