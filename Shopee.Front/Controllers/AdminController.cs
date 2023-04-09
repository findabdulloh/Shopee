using Microsoft.AspNetCore.Mvc;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Service.DTOs.Users;
using Shopee.Service.Interfaces;
using Shopee.Service.Services;

namespace Shopee.Web.Controllers
{
	public class AdminController : Controller
	{
        private static IUserRepository repo = new UserRepository();
        private IUserService userservice = new UserService(repo);
        public async Task<IActionResult> Users()
		{
			var users = await this.userservice.GetAllAsync();
			return View(users);
		}
        public async Task<IActionResult> Orders()
        {
            return View();
        }
        public async Task<IActionResult> Product()
        {
            return View();
        }
        public async Task<IActionResult> Questions()
        {
            return View();
        }
        public IActionResult Category()
        {
            return View();
        }
    }
}
