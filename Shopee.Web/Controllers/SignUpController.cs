using Microsoft.AspNetCore.Mvc;

namespace Shopee.Web.Controllers
{
	public class SignUpController : Controller
	{
		public IActionResult Index()
		{
			ViewData["Title"] = "Login";
			ViewData["Layout"] = null;
			return View();
		}
	}
}
