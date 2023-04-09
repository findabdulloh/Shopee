using Microsoft.AspNetCore.Mvc;
using Shopee.Domain.Entities;

namespace Shopee.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Login";
            ViewData["Layout"] = null;
            return View();
        }

        public IActionResult Check(User user)
        {
            if(user.UserName == "admin" && user.Password == "admin")
            {
                var model = Tuple.Create(user.UserName, user.Password);
                return View("Admin", model);
            }
            return View("User");
        }

        public IActionResult Admin(Tuple<string , string> user)
        {
            return View(user.Item1, user.Item2);
        }

        public IActionResult User()
        {
            return View();
        }
    }
}
