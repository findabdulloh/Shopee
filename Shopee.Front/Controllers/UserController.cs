using Microsoft.AspNetCore.Mvc;
using Shopee.Service.DTOs.Users;

namespace Shopee.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(UserViewDto user)
        {
            return View(user);
        }
    }
}
