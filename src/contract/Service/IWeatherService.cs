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
        /// <param name="latitude">The latitude coordinate on Earth</param>
        /// <param name="longitude">The longitude coordinate on Earth</param>
        /// <returns>The weather conditions matching the Earth coordinates</returns>
        Task<WeatherConditions> GetWeatherAsync(double latitude, double longitude);

        /// <summary>
        /// Get the current weather conditions by the city and country
        /// </summary>
        /// <param name="city"></param>
        /// <param name="countryCode"></param>
        /// <returns>The weather conditions matching the city and country</returns>
        Task<WeatherConditions> GetWeatherAsync(string city, string countryCode = null);

        /// <summary>
        /// Get the current weather conditions by the country and postal code
        /// </summary>
        /// <param name="country"></param>
        /// <param name="zip"></param>
        /// <returns></returns>
        Task<WeatherConditions> GetWeatherAsync(string country, int zip = 0);
    }
}
