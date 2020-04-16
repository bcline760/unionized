using System;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public class HaSwitchAttributes
    {
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
    }
}
