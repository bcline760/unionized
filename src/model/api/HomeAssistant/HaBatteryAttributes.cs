using System;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public class HaBatteryAttributes
    {
        [JsonProperty("account_fetch_interval", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? AccountFetchInterval { get; set; }

        [JsonProperty("battery", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Battery { get; set; }

        [JsonProperty("battery_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string BatteryStatus { get; set; }

        [JsonProperty("device_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceName { get; set; }

        [JsonProperty("device_status", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceStatus { get; set; }

        [JsonProperty("low_power_mode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? LowPowerMode { get; set; }

        [JsonProperty("owner_fullname", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string OwnerFullname { get; set; }

        [JsonProperty("battery_level", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? BatteryLevel { get; set; }
    }
}
