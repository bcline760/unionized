using System.Collections.Generic;
using System.Threading.Tasks;
using Unionized.Contract;

namespace Unionized.Interface.Service
{
    public interface IMonitoredServerService : IUnionizedService<MonitoredServer>
    {
        Task<List<MonitoredServer>> CheckServers();
    }
}