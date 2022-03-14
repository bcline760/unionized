using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unionized.Contract;
using Unionized.Contract.Service;

namespace Unionized.Api.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : UnionizedController
    {
        public HomeController(IHomeService service)
        {
            Service = service;
        }

        [HttpGet, Route("{deviceId}")]
        public async Task<IActionResult> GetDeviceAsync(string deviceId)
        {
            var result = await ExecuteServiceMethod(Service.GetStateAsync, deviceId, "GetDeviceAsync", DesiredStatusCode.OK);

            return result;
        }

        [HttpGet,Route("{deviceId}/on")]
        public async Task<IActionResult> TurnOnAsync(string deviceId)
        {
            var result = await ExecuteServiceMethod(Service.ToggleSwitchedEntityAsync, deviceId, true, "TurnOnAsync", DesiredStatusCode.OK);

            return result;
        }

        [HttpGet, Route("{deviceId}/off")]
        public async Task<IActionResult> TurnOffAsync(string deviceId)
        {
            var result = await ExecuteServiceMethod(Service.ToggleSwitchedEntityAsync, deviceId, false, "TurnOffAsync", DesiredStatusCode.OK);

            return result;
        }

        public IHomeService Service { get; }
    }
}
