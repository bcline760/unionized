using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Contract.Service;

namespace Unionized.Service
{
    internal class WeatherService : IWeatherService
    {
        public WeatherService(IWeatherRepository weather)
        {
            Repository = weather;
        }

        public IWeatherRepository Repository { get; private set; }

        public async Task<WeatherConditions> GetWeatherAsync(double latitude, double longitude)
        {
            return await Repository.GetConditionsAsync(longitude, latitude);
        }

        public async Task<WeatherConditions> GetWeatherAsync(string city, string countryCode = null)
        {
            return await Repository.GetConditionsAsync(city, countryCode);
        }

        public async Task<WeatherConditions> GetWeatherAsync(string country, int zip = 0)
        {
            return await Repository.GetConditionsAsync(country, zip);
        }
    }
}
