using Microsoft.AspNetCore.Mvc;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Service.DTOs;
using Shopee.Service.Interfaces;
using Shopee.Service.Services;

namespace Shopee.Web.Controllers
{
	public class SignUpController : Controller
	{
		private IUserService userservice = new UserService();
		public IActionResult Index()
		{
			ViewData["Title"] = "Login";
			ViewData["Layout"] = null;
			return View();
		}
		public async Task<IActionResult> Create(UserCreationDto user)
		{
			var userForCreate = await this.userservice.CreateAsync(user);
			if(userForCreate is null)
				return BadRequest("User already exist");

			return RedirectToAction("Index", "Login");
		}
	}
}
