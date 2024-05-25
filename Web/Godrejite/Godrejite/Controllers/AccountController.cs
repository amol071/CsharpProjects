// Controllers/AccountController.cs
using System.Linq;
using System.Web.Mvc;
using Godrejite.Models;

namespace Godrejite.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        #region GET METHODS
        // GET: Account/Login
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Login()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: Account/ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region POST METHODS
        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.Username == model.Username);

                if (user != null)
                {
                    if (user.Password == model.Password)
                    {
                        // Set up the user session or authentication ticket
                        Session["UserId"] = user.Id;
                        Session["Username"] = user.Username; // Optional: Store username in session
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect password.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username not found.");
                }
            }
            return View(model);
        }
        #endregion

    }
}
