using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Unionized.Model.API
{
    internal abstract class ApiRepository
    {
        protected async Task<TContract> GetFromApiAsync<TContract, TModel>(string method, ApiEndpoint endpoint, Func<TModel,TContract> mapFunc)
        {
            HttpClient hc = null;
            try
            {
                hc = new HttpClient();
                hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", endpoint.ApiKey);

                string url = $"{endpoint.Endpoint}/{method}";
                var response = await hc.GetAsync(url, HttpCompletionOption.ResponseContentRead);
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

        protected async Task<TContract> SendToApiAsync<TContract, TModel>(string method, TContract body, ApiEndpoint endpoint, Func<TModel, TContract> mapFunc)
        {
            HttpClient hc = null;
            try
            {
                hc = new HttpClient();
                hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", endpoint.ApiKey);

                string url = $"{endpoint.Endpoint}/{method}";
                string jsonBody = JsonConvert.SerializeObject(body);
                var content = new StringContent(jsonBody);
                var response = await hc.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

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
