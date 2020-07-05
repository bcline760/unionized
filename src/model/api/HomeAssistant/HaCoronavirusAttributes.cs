using System;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public class HaCoronavirusAttributes : HaAttributes
    {
        public HaCoronavirusAttributes()
        {
        }
        [JsonProperty("attribution", Required = Required.Always)]
        public string Attribution { get; set; }

        [JsonProperty("unit_of_measurement", Required = Required.Always)]
        public string UnitOfMeasurement { get; set; }
    }
}
