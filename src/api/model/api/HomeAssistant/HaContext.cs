using System;
using Newtonsoft.Json;

namespace Unionized.Model.API.HomeAssistant
{
    public partial class HaContext
    {
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("parent_id", Required = Required.AllowNull)]
        public string ParentId { get; set; }

        [JsonProperty("user_id", Required = Required.AllowNull)]
        public object UserId { get; set; }
    }
}
