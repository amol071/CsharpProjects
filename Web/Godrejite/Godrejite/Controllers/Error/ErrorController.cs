// Controllers/Error/ErrorController.cs
using System.Web.Mvc;

namespace Godrejite.Controllers.Error
{
    public class ErrorController : Controller
    {
        // GET: Error/NotFound
        public ActionResult NotFound()
        {
            return View();
        }

        // Optionally, handle other types of errors
        public ActionResult General()
        {
            return View();
        }
    }
}
