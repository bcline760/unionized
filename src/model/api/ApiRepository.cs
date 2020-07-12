using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Unionized.Model.API
{
    internal abstract class ApiRepository
    {
        protected ApiRepository(ApiEndpoint endpoint)
        {
            Endpoint = endpoint;
        }

        protected async Task<string> GetFromApiAsync(string method)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Endpoint.ApiKey);

                string url = $"{Endpoint.Endpoint}/{method}";
                var response = await hc.GetAsync(url, HttpCompletionOption.ResponseContentRead);
                response.EnsureSuccessStatusCode(); //Fail if there is a problem with the request

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }

        protected async Task<string> SendToApiAsync(string method, string body)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Endpoint.ApiKey);

                string url = $"{Endpoint.Endpoint}/{method}";
                var content = new StringContent(body);
                var response = await hc.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
        }

        protected ApiEndpoint Endpoint { get; }
    }
}
