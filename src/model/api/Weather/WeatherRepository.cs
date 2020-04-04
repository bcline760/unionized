using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Unionized.Contract;
using Unionized.Contract.Repository;
using Newtonsoft.Json;

namespace Unionized.Model.API.Weather
{
    internal class WeatherRepository : ApiRepository, IWeatherRepository
    {
        public WeatherRepository(UnionizedConfiguration config)
        {
            Configuration = config;
        }

        public async Task<WeatherConditions> GetConditionsAsync(string city, string countryCode = null)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}?q={1}", Configuration.Weather.Endpoint, city);
            if (!string.IsNullOrEmpty(countryCode))
                sb.AppendFormat(",{0}", countryCode);

            sb.AppendFormat("&appid={0}", Configuration.Weather.ApiKey);
            string url = sb.ToString();

            try
            {
                return await GetFromApiAsync<WeatherConditions,WeatherModel>(url, MapConditions);
            }
            catch (HttpRequestException hre)
            {
                //TODO: Log
                throw;
            }
        }

        public async Task<WeatherConditions> GetConditionsAsync(string country, int zip=0)
        {
            string zipCode = zip == 0 ? country : $"{country},{zip}";
            string url = $"{Configuration.Weather.Endpoint}?zip={zipCode}&appid={Configuration.Weather.ApiKey}";

            try
            {
                return await GetFromApiAsync<WeatherConditions, WeatherModel>(url, MapConditions);
            }
            catch (HttpRequestException hre)
            {
                //TODO: Log
                throw;
            }
        }

        public async Task<WeatherConditions> GetConditionsAsync(double longitude, double latitude)
        {
            string url = $"{Configuration.Weather.Endpoint}?lat={latitude}&lon={longitude}&appid={Configuration.Weather.ApiKey}";
            
            try
            {
                return await GetFromApiAsync<WeatherConditions, WeatherModel>(url, MapConditions);
            }
            catch (HttpRequestException hre)
            {
                //TODO: Log
                throw;
            }
        }

        private WeatherConditions MapConditions(WeatherModel model)
        {
            if (model==null)
                throw new ArgumentNullException(nameof(model));

            var weatherConditions = new WeatherConditions
            {
                CloudCover = (byte)model.Clouds.All,
                CurrentPressure = model.Main.Pressure,
                CurrentTemperature = (model.Main.Temp - 273.15),
                Date = new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(model.Dt),
                MaximumTemperature = (model.Main.MaximumTemperatureK - 273.15),
                MinimumTemperature = (model.Main.MinimumTemperatureK - 273.15),
                RelativeHumidity = (byte)model.Main.Humidity,
                StationId = (int)model.Id,
                Sunrise = new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(model.Sys.Sunrise),
                Sunset = new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(model.Sys.Sunset),
                Visibility = model.Visibility,
                WindDirection = (short)model.Wind.Deg,
                WindSpeed = model.Wind.Speed
            };

            if (model.Rain !=null)
            {
                weatherConditions.RainTotal = model.Rain.OneHourTotal;
            }

            return weatherConditions;
        }
    }
}
