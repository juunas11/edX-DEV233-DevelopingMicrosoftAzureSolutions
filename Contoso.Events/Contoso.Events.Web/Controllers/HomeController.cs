using Contoso.Events.ViewModels;
using System;
using System.Web.Mvc;

namespace Contoso.Events.Web.Controllers
{
    public class HomeController : Controller
    {
        private const int EVENTS_GRID_SIZE = 10;
        
        public ActionResult Index()
        {
            EventsViewModel viewModel = new EventsViewModel();

            return View(viewModel);
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