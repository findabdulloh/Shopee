using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Service.DTOs.Products;
using Shopee.Service.DTOs.Users;
using Shopee.Service.Interfaces;
using Shopee.Service.Services;

namespace Shopee.Web.Controllers
{
    public class UserController : Controller
    {
        private ICategoryService categoryService = new CategoryService();
        private IProductService productservice = new ProductService();
        public IActionResult Index(UserViewDto user)
        {

            return View(user);
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
        public async Task<IActionResult> Products()
        {
            var products = await this.productservice.GetAllAsync();
            var categories = await this.categoryService.GetAllAsync();
            return View(new Tuple<List<ProductViewDto>, List<Category>>(products, categories));
        }
        public async Task<IActionResult> FilteredByCategory(int? category)
        {
            var categoryFind = await this.categoryService.GetByIdAsync(Convert.ToInt64(category));
            var products = (await this.productservice.GetAllAsync()).Where(c=> c.CategoryName == categoryFind.Name).ToList();
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
    }
}
