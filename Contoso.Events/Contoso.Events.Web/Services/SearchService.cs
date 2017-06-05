using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Contoso.Events.Models;
using Newtonsoft.Json;

namespace Contoso.Events.Web.Services
{
    public class SearchService
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task<AzureSearchResult<EventSearchResult>> SearchEventsAsync(string term)
        {
            string url = $"https://aa-events-prod-search.search.windows.net/indexes/aa-events-index/docs?search={term}&api-version=2016-09-01";

            var req = new HttpRequestMessage(HttpMethod.Get, url);
            string accessKey = ConfigurationManager.AppSettings["SearchAccessKey"];
            req.Headers.Add("api-key", accessKey);
            req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await Client.SendAsync(req);

            string json = await res.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AzureSearchResult<EventSearchResult>>(json);
            return result;
        }
    }
}