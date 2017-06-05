using System.Threading.Tasks;
using System.Web.Http;
using Contoso.Events.Web.Services;

namespace Contoso.Events.Web.Controllers
{
    [RoutePrefix("api")]
    public class SearchController : ApiController
    {
        [HttpGet]
        [Route("search")]
        public async Task<IHttpActionResult> Search(string term = null)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                term = "*";
            }
            var searchService = new SearchService();

            var results = await searchService.SearchEventsAsync(term);

            return Ok(results.Items);
        }
    }
}
