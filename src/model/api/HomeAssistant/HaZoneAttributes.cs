using System;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public partial class HaZoneAttributes : HaAttributes
    {
        [JsonProperty("editable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Editable { get; set; }

        [JsonProperty("hidden", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidden { get; set; }

        [JsonProperty("icon", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("latitude", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Latitude { get; set; }

        [JsonProperty("longitude", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Longitude { get; set; }

        [JsonProperty("passive", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Passive { get; set; }

        [JsonProperty("radius", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Radius { get; set; }
    }
}
