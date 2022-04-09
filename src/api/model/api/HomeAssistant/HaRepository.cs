using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using AutoMapper;
using Newtonsoft.Json;
using Unionized.Contract;
using Unionized.Interface.Repository;
using Newtonsoft.Json.Linq;

namespace Unionized.Model.API.HomeAssistant
{
    internal class HaRepository : ApiRepository, IHaRepository
    {
        public HaRepository(ApiEndpoint endpoint) : base(endpoint)
        {
            Mapper = BuildMap();
        }

        public async Task<Dictionary<string, string>> GetAllEntityStatesAsync()
        {
            string method = @"/states";
            var properties = new string[] { "entity_id", "state" };

            var response = await GetFromApiAsync(method);
            var entities = new Dictionary<string, string>();
            using (TextReader tr = new StringReader(response))
            {
                using (JsonTextReader jtr = new JsonTextReader(tr))
                {
                    while (jtr.Read())
                    {
                        if (jtr.TokenType == JsonToken.StartObject)
                        {
                            var obj = JObject.Load(jtr);
                            entities.Add(obj["entity_id"].ToString(), obj["state"].ToString());
                        }
                    }
                }
            }

            return entities;
        }

        public async Task<EntityState> GetEntityStateAsync(string entityId)
        {
            string method = $"/states/{entityId}";

            var response = await GetFromApiAsync(method);
            var model = JsonConvert.DeserializeObject<HaState>(response);

            return Mapper.Map<EntityState>(model);
        }

        public async Task<EntityState> SetEntityStateAsync(string entityId, string state, string attributes = null)
        {
            string method = $"/states/{entityId}";
            string postBody = attributes == null ? $"{{\"state\": \"{state}\"}}" : $"{{\"state\": \"{state}\", \"attributes\": {attributes} }}";

            var response = await SendToApiAsync(method, postBody);
            var model = JsonConvert.DeserializeObject<HaState>(response);

            return Mapper.Map<EntityState>(model);
        }

        public async Task<EntityState> CallServiceAsync(string entityId, ServiceDomain domain, string service)
        {
            string method = $"/services/{domain.ToString().ToLowerInvariant()}/{service}";
            string postBody = $"{{\"entity_id\": \"{entityId}\"}}";

            var response = await SendToApiAsync(method, postBody);
            var model = JsonConvert.DeserializeObject<HaState>(response);

            return Mapper.Map<EntityState>(model);
        }

        private IMapper BuildMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EntityState, HaState>().ReverseMap();
            });

            var map = config.CreateMapper();

            return map;
        }

        protected IMapper Mapper { get; }
    }
}
