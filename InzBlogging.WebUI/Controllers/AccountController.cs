using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using InzBlogging.Repository;
using InzBlogging.Models;

namespace InzBlogging.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccount _account;

        public AccountController(IUserAccount account)
        {
            _account = account;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection data)
        {
            string email = data["EmailAddress"];
            string password = data["Password"];

            var dbUser = _account.GetUserForLogin(email, password);

            if (dbUser!=null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.UtcNow.AddDays(30);
                Response.Cookies.Append("user-access-token", dbUser.AccessToken, options);
                return Redirect("/Home/Index");
            }
            ViewBag.Error = "Your User Name or Password is incorrect";
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            string confirmationToken = _account.Register(user);

            if (string.IsNullOrEmpty(confirmationToken))
            {
                ViewBag.Error = "Error Occured";
                return View();
            }
            else
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.UtcNow.AddDays(30);
                Response.Cookies.Append("user-access-token", user.AccessToken, options);
                return Redirect("/Home/Index");
            }

        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("user-access-token");
            return Redirect("/Home/Index");
        }

    }
}
