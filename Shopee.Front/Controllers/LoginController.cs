using Microsoft.AspNetCore.Mvc;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using Shopee.Service.DTOs.Users;
using Shopee.Service.Interfaces;
using Shopee.Service.Services;

namespace Shopee.Web.Controllers
{
    public class LoginController : Controller
    {
        private static IUserRepostory repo = new UserRepostory();
        private IUserService userservice = new UserService(repo);
        public IActionResult Index()
        {
            ViewData["Title"] = "Login";
            ViewData["Layout"] = null;
            return View();
        }

        public async Task<IActionResult> Check(User user)
        {
            var userChech = await this.userservice.LoginAsync(user.UserName, user.Password);
            if(userChech is not null)
            {
                if(userChech.Role == UserRole.Admin)
                    return View("Admin", userChech);
            
                if(userChech.Role == UserRole.Customer)
                    return View("User", userChech);
            }
            return BadRequest("User is not found");
        }

        public IActionResult Admin(UserViewDto user)
        {
            return View("/Views/Admin/Index.cshtml", user);
        }

        public IActionResult User(UserViewDto user)
        {
            return RedirectToAction("Index", "User", user);
        }
    }
}
