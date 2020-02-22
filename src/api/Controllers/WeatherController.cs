using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unionized.Contract.Service;

namespace Unionized.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class WeatherController : UnionizedController
    {
        public WeatherController(IWeatherService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetByPostalCode(string postalCode, string country)
        {
            //var result = await Service.GetWeatherAsync(country, postalCode);
            return Ok();
        }

        public async Task<IActionResult> GetByCoordinates(double longitude, double latitude)
        {
            var result = await Service.GetWeatherAsync(latitude, longitude);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        protected IWeatherService Service { get; private set; }
    }
}