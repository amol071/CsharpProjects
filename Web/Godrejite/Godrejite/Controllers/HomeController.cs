// Controllers/HomeController.cs
using System.Web.Mvc;

namespace Godrejite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
