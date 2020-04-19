using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Unionized.Contract;
using Unionized.Contract.Service;

namespace Unionized.Api.Controllers
{
    [Route("api/[controller]")]
    public class ServerController : UnionizedDataController<MonitoredServer>
    {
        public ServerController(IMonitoredServerService service) : base(service)
        {
        }

        [Route("check")]
        public async Task<IActionResult> CheckServers()
        {
            var svc = (IMonitoredServerService)Service;

            var result = await ExecuteServiceMethod(svc.CheckServers, "CheckServers", DesiredStatusCode.OK);

            return result;
        }
    }
}
