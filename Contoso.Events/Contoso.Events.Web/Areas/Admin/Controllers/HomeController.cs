using Contoso.Events.Models;
using Contoso.Events.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contoso.Events.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            EventsViewModel viewModel = new EventsViewModel();

            return View(viewModel);
        }

        public ActionResult SignIn(string id)
        {
            SignInSheetViewModel viewModel = null;

            if (!String.IsNullOrEmpty(id))
            {
                viewModel = new SignInSheetViewModel(
                    eventKey: id
                );
            }

            if (viewModel == null)
            {
                return new HttpNotFoundResult();
            }

            return View(viewModel);
        }

        public async Task<ActionResult> GetSignInUrl(string id)
        {
            string filename = String.Format("{0}.docx", id);

            DownloadViewModel viewModel = new DownloadViewModel(
                blobId: filename
            );

            string blobUrl = await viewModel.GetSecureUrl();

            return Redirect(blobUrl);
        }
    }
}