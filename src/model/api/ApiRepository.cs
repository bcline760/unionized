using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Unionized.Model.API
{
    internal abstract class ApiRepository
    {
        protected async Task<TContract> GetFromApiAsync<TContract, TModel>(string url, Func<TModel,TContract> mapFunc)
        {
            HttpClient hc = null;
            try
            {
                if (Configuration.IsDevelopment)
                {
                    //Development, ignore invalid certificates usually because self signed.
                    var handler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };
                    hc = new HttpClient(handler);
                }
                else
                    hc = new HttpClient();

                var response = await hc.GetAsync(url);
                response.EnsureSuccessStatusCode(); //Fail if there is a problem with the request

                var responseContent = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<TModel>(responseContent);
                var contract = mapFunc(model);

                return contract;
            }
            finally
            {
                if (hc != null)
                    hc.Dispose();
            }
        }

        protected UnionizedConfiguration Configuration { get; set; }
    }
}
