using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unionized.Contract.Service
{
    public interface IWeatherService
    {
        /// <summary>
        /// Get the current weather conditions based on the current points
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        Task<WeatherConditions> GetWeatherAsync(double latitude, double longitude);
    }
}
