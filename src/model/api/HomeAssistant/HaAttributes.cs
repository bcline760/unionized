using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public abstract class HaAttributes
    {
        [JsonProperty("friendly_name", Required = Required.Always)]
        public string FriendlyName { get; set; }

        [JsonProperty("device_class", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceClass { get; set; }

        [JsonProperty("source_list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SourceList { get; set; }

        [JsonProperty("supported_features", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? SupportedFeatures { get; set; }

        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("user_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("newest_version", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string NewestVersion { get; set; }

        [JsonProperty("release_notes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri ReleaseNotes { get; set; }

        [JsonProperty("last_triggered")]
        public DateTimeOffset? LastTriggered { get; set; }
    }
}
