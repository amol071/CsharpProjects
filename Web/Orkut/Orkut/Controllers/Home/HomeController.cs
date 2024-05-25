using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orkut.Controllers.Home
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                ViewBag.Username = Session["Username"].ToString();
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
    }
}