using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unionized.Contract;

namespace Unionized.Api.Container
{
    public class ApiResponse<TContract>
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }

        [JsonProperty("data", Required = Required.AllowNull,
            IsReference = true,
            NullValueHandling = NullValueHandling.Include,
            ReferenceLoopHandling = ReferenceLoopHandling.Error)]
        public TContract Data { get; set; }

        [JsonProperty("message", Required = Required.AllowNull, IsReference = false)]
        public string Message { get; set; }
    }
}
