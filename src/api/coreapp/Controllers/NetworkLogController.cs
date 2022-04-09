using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Unionized.Contract;
using Unionized.Interface.Service;

namespace Unionized.Api.Controllers
{
    [Route("api/[controller]")]
    public class NetworkLogController : UnionizedDataController<NetworkLog>
    {
        public NetworkLogController(INetworkLogService netLogService) : base(netLogService)
        {
        }

        [HttpGet, Route("srcprt/{port}")]
        public async Task<IActionResult> GetBySourcePortAsync(int port)
        {
            var svc = (INetworkLogService)Service;

            var result = await ExecuteServiceMethod<int?,int?,List<NetworkLog>>(svc.GetLogsByPort, port, null, "GetBySourcePortAsync", DesiredStatusCode.OK);
            return result;
        }

        [HttpGet, Route("dstprt/{port}")]
        public async Task<IActionResult> GetByDestPortAsync(int port)
        {
            var svc = (INetworkLogService)Service;

            var result = await ExecuteServiceMethod<int?, int?, List<NetworkLog>>(svc.GetLogsByPort, null, port, "GetBySourcePortAsync", DesiredStatusCode.OK);
            return result;
        }

        [HttpGet, Route("logs")]
        public async Task<IActionResult> GetByDatesAsync(DateTime? after, DateTime? before)
        {
            if (after == null && before == null)
                return BadRequest();

            var svc = (INetworkLogService)Service;
            var result = await ExecuteServiceMethod(svc.GetLogsByDate, after, before, "GetLogsByDate", DesiredStatusCode.OK);

            return result;
        }
    }
}
