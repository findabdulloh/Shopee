using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using Shopee.Service.DTOs.Categories;
using Shopee.Service.DTOs.Messages;
using Shopee.Service.DTOs.Products;
using Shopee.Service.DTOs.Users;
using Shopee.Service.Interfaces;
using Shopee.Service.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace Shopee.Web.Controllers
{
	public class AdminController : Controller
	{
        private IUserService userservice = new UserService();
		private IProductService productservice = new ProductService();
        private ICategoryService categoryservice = new CategoryService();
        private IMessageService messageService  = new MessageService();
        private IOrderService orderService  = new OrderService();
        public async Task<IActionResult> Users()
		{
			var users = await this.userservice.GetAllAsync();
			return View(users);
		}
        public async Task<IActionResult> Orders()
        {
            var orders = await this.orderService.GetAllAsync(o=> o.Id > 0);
            return View(orders);
        }
        public async Task<IActionResult> Questions()
        {
            var questions = await this.messageService.GetAllQuestionsAsync();
            return View(questions);
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
		
		public IActionResult AnswerMessage(long id, long userId)
        {
			Response.Cookies.Append("id", JsonConvert.SerializeObject(id));
			Response.Cookies.Append("userId", JsonConvert.SerializeObject(userId));
			return View();
        }
		public async Task<IActionResult> SendMessage(MessageCreationDto message, long id)
		{
			var userId = Request.Cookies["userId"];
			long userId2 = JsonConvert.DeserializeObject<long>(userId);

			var idJson = Request.Cookies["id"];
			long repid = JsonConvert.DeserializeObject<long>(idJson);

			var newMessage = new MessageCreationDto()
			{
                UserId = userId2,
				RepliedMessageId = repid,
				Text = message.Text,
				Type = MessageType.Answer,
			};
			var result = await this.messageService.CreateAsync(newMessage);
			return RedirectToAction("Questions");
		}

		public async Task<IActionResult> DeleteCategory(long id)
		{
			await this.categoryservice.DeleteAsync(id);
			return RedirectToAction("Category");
		}

        public async Task<IActionResult> UpdateCategory(long id)
        {
            ViewBag.idcategory = id;
            return View();
        }

        public async Task<IActionResult> UpdateCategoryEnd(CategoryCreationDto category,long id)
        {
            var update = await this.categoryservice.ModifyAsync(id, category);
            return RedirectToAction("Category");
        }
        #region Product

        public IActionResult ProductCreate()
        {
            return View();
        }

        public IActionResult CategoryCreate()
        {
            return View();
        }
        public async Task<IActionResult> CategoryCreateEnd( CategoryCreationDto category)
        {
            var result = await this.categoryservice.CreateAsync(category);
            return RedirectToAction("Category");
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
