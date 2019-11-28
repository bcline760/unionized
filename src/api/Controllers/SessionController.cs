using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Unionized.Contract;
using Unionized.Contract.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unionized.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : UnionizedController
    {
        private ISessionService _session;

        public SessionController(ISessionService session)
        {
            _session = session;
            //_user = user;
        }

        [AllowAnonymous]
        [HttpPost,Route("login")]
        public async Task<IActionResult> LoginAsync(LogonRequest request)
        {
            if (request == null)
                return BadRequest();

            var logonResponse = await _session.AuthenticateAsync(request);
            return Ok(logonResponse);
        }

        [HttpGet,Route("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            return Ok();
        }
    }
}
