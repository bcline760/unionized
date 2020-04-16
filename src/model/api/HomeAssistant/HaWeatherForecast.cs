using System;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public partial class HaWeatherForecast
    {
        [JsonProperty("condition", Required = Required.Always)]
        public string Condition { get; set; }

        [JsonProperty("datetime", Required = Required.Always)]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("humidity", Required = Required.AllowNull)]
        public double? Humidity { get; set; }

        [JsonProperty("pressure", Required = Required.AllowNull)]
        public double? Pressure { get; set; }

        [JsonProperty("temperature", Required = Required.AllowNull)]
        public double? Temperature { get; set; }

        [JsonProperty("wind_bearing", Required = Required.AllowNull)]
        public double? WindBearing { get; set; }

        [JsonProperty("wind_speed", Required = Required.AllowNull)]
        public double? WindSpeed { get; set; }
    }
}
