using System;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public class HaAppleDeviceAttributes
    {
        [JsonProperty("gps_accuracy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? GpsAccuracy { get; set; }

        [JsonProperty("source_type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceType { get; set; }
    }
}
