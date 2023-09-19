using InzBlogging.Models;
using InzBlogging.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InzBlogging.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }
        //---------User
        [Admin]
        [HttpGet]
        public IActionResult Users()
        {
            return View(_user.GetUsers());
        }
        [Admin]
        [HttpGet]
        public IActionResult AddUpdateUser(int id=0)
        {
            return View(_user.GetUser(id));
        }
        //----------UserRole
        [Admin]
        [HttpGet]
        public IActionResult Roles()
        {
            return View(_user.GetRoles());
        }
        [Admin]
        [HttpGet]
        public IActionResult AddUpdateRole(int id=0)
        {
            return View(_user.GetRole(id));
        }
        [Admin]
        [HttpPost]
        public IActionResult AddUpdateRole(UserRole userRole)
        {
            _user.AddUpdateRole(userRole);
            return RedirectToAction("Roles");
        }
        [HttpGet]
        public IActionResult DeleteRole(int id) 
        {
            _user.DeleteRole(id);
            return RedirectToAction("Roles");
        }



    }
}
