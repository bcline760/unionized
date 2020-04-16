using System;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public partial class HaSolarAttributes : HaAttributes
    {
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
    }

}
