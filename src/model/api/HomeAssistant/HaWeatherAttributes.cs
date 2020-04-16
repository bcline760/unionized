using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public partial class HaWeatherAttributes : HaAttributes
    {
        [JsonProperty("attribution", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Attribution { get; set; }

        [JsonProperty("forecast", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<HaWeatherForecast> Forecast { get; set; }

        [JsonProperty("humidity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Humidity { get; set; }

        [JsonProperty("pressure", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Pressure { get; set; }

        [JsonProperty("temperature", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Temperature { get; set; }

        [JsonProperty("wind_bearing", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? WindBearing { get; set; }

        [JsonProperty("wind_speed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? WindSpeed { get; set; }
    }
}
