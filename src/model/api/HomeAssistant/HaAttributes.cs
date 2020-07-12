using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public sealed class HaAttributes
    {
        [JsonProperty("editable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Editable { get; set; }

        [JsonProperty("friendly_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string FriendlyName { get; set; }

        [JsonProperty("icon", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        #region Solar Attributes
        [JsonProperty("azimuth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Azimuth { get; set; }

        [JsonProperty("elevation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Elevation { get; set; }

        [JsonProperty("next_dawn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? NextDawn { get; set; }

        [JsonProperty("next_dusk", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? NextDusk { get; set; }

        [JsonProperty("next_midnight", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? NextMidnight { get; set; }

        [JsonProperty("next_noon", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? NextNoon { get; set; }

        [JsonProperty("next_rising", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? NextRising { get; set; }

        [JsonProperty("next_setting", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? NextSetting { get; set; }

        [JsonProperty("rising", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rising { get; set; }
        #endregion

        #region Zone Attributes
        [JsonProperty("hidden", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidden { get; set; }

        [JsonProperty("latitude", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Latitude { get; set; }

        [JsonProperty("longitude", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Longitude { get; set; }

        [JsonProperty("passive", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Passive { get; set; }

        [JsonProperty("radius", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Radius { get; set; }
        #endregion

        #region Weather Attributes
        [JsonProperty("attribution", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Attribution { get; set; }

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
        #endregion

        #region Switch Attributes
        [JsonProperty("current_a", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentA { get; set; }

        [JsonProperty("current_power_w", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentPowerW { get; set; }

        [JsonProperty("today_energy_kwh", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TodayEnergyKwh { get; set; }

        [JsonProperty("total_energy_kwh", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TotalEnergyKwh { get; set; }

        [JsonProperty("voltage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Voltage { get; set; }
        #endregion
    }
}
