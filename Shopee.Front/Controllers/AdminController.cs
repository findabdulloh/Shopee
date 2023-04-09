using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Products;
using Shopee.Service.DTOs.Users;
using Shopee.Service.Interfaces;
using Shopee.Service.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shopee.Web.Controllers
{
	public class AdminController : Controller
	{
        private static IUserRepository UserRepo = new UserRepository();
        private IUserService userservice = new UserService(UserRepo);

		private static IProductRepository ProductRepo = new ProductRepository();
		private IProductService productservice = new ProductService();

        private ICategoryService categoryservice = new CategoryService(); 
		public async Task<IActionResult> Users()
		{
			var users = await this.userservice.GetAllAsync();
			return View(users);
		}
        public async Task<IActionResult> Orders()
        {
            return View();
        }
        public async Task<IActionResult> Questions()
        {
            return View();
        }
        public async Task<IActionResult> Category()
        {
            var categories = await this.categoryservice.GetAllAsync();
            return View(categories);
        }

        public IActionResult Account()
        {
            var userJson = Request.Cookies["account"];
            if (userJson != null)
            {
                var user = JsonConvert.DeserializeObject<UserViewDto>(userJson);
                ViewBag.User = user;
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        #region Product

        public IActionResult ProductCreate()
        {
            return View();
        }
        public async Task<IActionResult> Product()
        {
            var products = await this.productservice.GetAllAsync();
            return View(products);
        }
        public async Task<IActionResult> ProductSearched(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return View();
            var products = await this.productservice.GetAllAsync();
            List<ProductViewDto> result = new List<ProductViewDto>();
            foreach (var product in products)
            {
                if (Convert.ToString(product.Id).Contains(search.ToLower()) || product.Name.ToLower().Contains(search.ToLower()) || Convert.ToString(product.Price).Contains(search.ToLower()) || product.Description.ToLower().Contains(search.ToLower()))
                {
                    result.Add(product);
                }
            }
            return View(result);
        }
        public async Task<IActionResult> DeleteProduct(long id)
        {
            await this.productservice.DeleteAsync(id);
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> CreateProduct(ProductCreationDto product)
        {
            var productExist = await this.productservice.CreateAsync(product);
            if(productExist is null)
            {
                return BadRequest("Product is already exist you can update product");
            }
            return RedirectToAction("Product");
        }
        public IActionResult UpdateProduct(long id)
        {
            ViewBag.id = id;
            return View();
        }
        public async Task<IActionResult> UpdateProductService(long id, ProductCreationDto product)
        {
            //long id = Convert.ToInt64((ViewBag.id).ToString());
            await this.productservice.ModifyAsync(id, product);
            return RedirectToAction("Product");
        }
        #endregion

    }
}
