using Contoso.Events.ViewModels;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Contoso.Events.Models;
using Contoso.Events.Web.Services;
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
            var searchService = new SearchService();

            model.Term = searchTerm;
            var results = await searchService.SearchEventsAsync(searchTerm);
            model.SearchResults = results.Items;

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