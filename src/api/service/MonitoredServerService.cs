using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Text;

using Unionized.Contract;
using Unionized.Interface.Service;
using Unionized.Interface.Repository;

namespace Unionized.Service
{
    public class MonitoredServerService : UnionizedService<MonitoredServer>, IMonitoredServerService
    {
        public MonitoredServerService(IMonitorServersRepository repo) : base(repo)
        {
        }

        public async Task<List<MonitoredServer>> CheckServers()
        {
            var serverList = new List<MonitoredServer>(await GetAllAsync());
            foreach (var s in serverList)
            {
                s.Online = CheckServer(s);
            }

            return serverList;
        }

        private bool CheckServer(MonitoredServer s)
        {
            string data = "data";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 10;

            using (var ping = new Ping())
            {
                var opts = new PingOptions();
                opts.DontFragment = true;
                var reply = ping.Send(s.IpAddress, timeout, buffer, opts);

                return reply.Status == IPStatus.Success;
            }
        }
    }
}
