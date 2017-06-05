using Contoso.Events.ViewModels;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Contoso.Events.Models;
using Newtonsoft.Json;

namespace Contoso.Events.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient Client = new HttpClient();

        public ActionResult Index()
        {
            EventsViewModel viewModel = new EventsViewModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Search(SearchViewModel model)
        {
            string searchTerm = model.Term;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = "*";
            }
            string url = $"https://aa-events-prod-search.search.windows.net/indexes/aa-events-index/docs?search={searchTerm}&api-version=2016-09-01";

            var req = new HttpRequestMessage(HttpMethod.Get, url);
            string accessKey = ConfigurationManager.AppSettings["SearchAccessKey"];
            req.Headers.Add("api-key", accessKey);
            req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await Client.SendAsync(req);

            string json = await res.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AzureSearchResult<EventSearchResult>>(json);

            model.Term = searchTerm;
            model.SearchResults = result.Items;

            return View(model);
        }

        public ActionResult Event(string id)
        {
            EventViewModel viewModel = null;

            if (!String.IsNullOrEmpty(id))
            {
                viewModel = new EventViewModel(
                    eventKey: id
                );
            }

            if (viewModel == null)
            {
                return new HttpNotFoundResult();
            }

            return View(viewModel);
        }

        public ActionResult Register(string id)
        {
            RegisterViewModel viewModel = null;

            if (!String.IsNullOrEmpty(id))
            {
                viewModel = new RegisterViewModel(
                    eventKey: id
                );
            }

            if (viewModel == null)
            {
                return new HttpNotFoundResult();
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.PersistRegistration())
                {
                    return View("Registered", viewModel.Registration.Id);
                }
            }

            return View(viewModel);
        }
    }
}