using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unionized.Contract.Repository
{
    public interface IWeatherRepository
    {
        /// <summary>
        /// Get the current weather conditions by city and country code if provided
        /// </summary>
        /// <param name="city">The name of the city</param>
        /// <param name="countryCode">Optional, provide the country code as well. Useful for city names duplicated in countries (e.g. Ontario)</param>
        /// <returns>The weather conditions for the given city</returns>
        public Task<WeatherConditions> GetConditionsAsync(string city, string countryCode = null);

        /// <summary>
        /// Get current weather conditions by the postal code and country
        /// </summary>
        /// <param name="country">The two digit country code</param>
        /// <param name="zip">The country's postal code</param>
        /// <returns></returns>
        public Task<WeatherConditions> GetConditionsAsync(string country, int zip);

        /// <summary>
        /// Get current conditions given geographical coordinates
        /// </summary>
        /// <param name="longitude">The longitude coordinate on Earth</param>
        /// <param name="latitude">The latitude coordinate on Earth</param>
        /// <returns>The weather conditions for the current geographical coordinate</returns>
        public Task<WeatherConditions> GetConditionsAsync(double longitude, double latitude);
    }
}
