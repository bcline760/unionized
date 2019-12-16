namespace Unionized.Model.API.Weather
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WeatherModel
    {
        [JsonProperty("coord", Required = Required.Always)]
        public Coord Coord { get; set; }

        [JsonProperty("weather", Required = Required.Always)]
        public List<Weather> Weather { get; set; }

        [JsonProperty("base", Required = Required.Always)]
        public string Base { get; set; }

        [JsonProperty("main", Required = Required.Always)]
        public Main Main { get; set; }

        [JsonProperty("visibility", Required = Required.Always)]
        public long Visibility { get; set; }

        [JsonProperty("wind", Required = Required.Always)]
        public Wind Wind { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("clouds", Required = Required.Always)]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt", Required = Required.Always)]
        public long Dt { get; set; }

        [JsonProperty("sys", Required = Required.Always)]
        public Sys Sys { get; set; }

        [JsonProperty("timezone", Required = Required.Always)]
        public long Timezone { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("cod", Required = Required.Always)]
        public long ReturnCode { get; set; }
    }

    public partial class Clouds
    {
        [JsonProperty("all", Required = Required.Always)]
        public long All { get; set; }
    }

    public partial class Coord
    {
        [JsonProperty("lon", Required = Required.Always)]
        public double Lon { get; set; }

        [JsonProperty("lat", Required = Required.Always)]
        public double Lat { get; set; }
    }

    public partial class Main
    {
        [JsonProperty("temp", Required = Required.Always)]
        public double Temp { get; set; }

        [JsonProperty("pressure", Required = Required.Always)]
        public long Pressure { get; set; }

        [JsonProperty("humidity", Required = Required.Always)]
        public long Humidity { get; set; }

        [JsonProperty("temp_min", Required = Required.Always)]
        public double MinimumTemperatureK { get; set; }

        [JsonProperty("temp_max", Required = Required.Always)]
        public double MaximumTemperatureK { get; set; }
    }

    public partial class Rain
    {
        [JsonProperty("1h", Required = Required.Always)]
        public double OneHourTotal { get; set; }
    }

    public partial class Sys
    {
        [JsonProperty("type", Required = Required.Always)]
        public long Type { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("country", Required = Required.Always)]
        public string Country { get; set; }

        [JsonProperty("sunrise", Required = Required.Always)]
        public long Sunrise { get; set; }

        [JsonProperty("sunset", Required = Required.Always)]
        public long Sunset { get; set; }
    }

    public partial class Weather
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("main", Required = Required.Always)]
        public string Main { get; set; }

        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty("icon", Required = Required.Always)]
        public string Icon { get; set; }
    }

    public partial class Wind
    {
        [JsonProperty("speed", Required = Required.Always)]
        public double Speed { get; set; }

        [JsonProperty("deg", Required = Required.Always)]
        public long Deg { get; set; }
    }
}
