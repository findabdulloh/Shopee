using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shopee.Data.IRepositories;
using Shopee.Data.Repositories;
using Shopee.Domain.Entities;
using Shopee.Domain.Enums;
using Shopee.Service.DTOs.Carts;
using Shopee.Service.DTOs.Messages;
using Shopee.Service.DTOs.OrderItems;
using Shopee.Service.DTOs.Orders;
using Shopee.Service.DTOs.Payments;
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
        private IMessageService messageService = new MessageService();
        private ICartService cartService = new CartService();
        private IOrderItemService ItemService   = new OrderItemService();
        private IOrderService orderService = new OrderService();
        public IActionResult Index(UserViewDto user)
        {

            return View(user);
        }
        public async Task<IActionResult> Cart()
        {
            var userJson = Request.Cookies["account"];
            var user = JsonConvert.DeserializeObject<UserViewDto>(userJson);
            var carts = await this.cartService.GetByUserIdAsync(user.Id);
            decimal totalPrice = 0;
            foreach (var item in carts.Items)
                totalPrice += item.TotalPrice;
            return View(new Tuple<CartViewDto, decimal>(carts, totalPrice));
        }
        public async Task<IActionResult> OrderCart()
        {
            return View();
        }

        public async Task<IActionResult> RemoveFromCart(long id)
        {
            var userJson = Request.Cookies["account"];
            var user = JsonConvert.DeserializeObject<UserViewDto>(userJson);
            var remove = await this.cartService.DropItemAsync(user.Id, id);
            return RedirectToAction("Cart");
        }
        public async Task<IActionResult> OrderCreate(PaymentCreationDto payment)
        {
            var userJson = Request.Cookies["account"];
            var user = JsonConvert.DeserializeObject<UserViewDto>(userJson);
            var newOrder = new OrderCreationDto()
            {
                UserId = user.Id,
                Payment = new PaymentCreationDto()
                {
                    Type = payment.Type,
                    UserId = user.Id
                },
            };
            await this.orderService.CreateAsync(newOrder);
            return RedirectToAction("Cart");
        }


        public IActionResult Account()
        {
            var userJson = Request.Cookies["account"];
            if (userJson != null)
            {
                var user = JsonConvert.DeserializeObject<UserViewDto>(userJson);
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
        public async Task<IActionResult> AddToCard(long id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        public  async Task<IActionResult> AddedtoCart(OrderItemCreationDto ordetitem)
        {
			var userJson = Request.Cookies["account"];
			var user = JsonConvert.DeserializeObject<UserViewDto>(userJson);
            var result = await this.cartService.AddItemAsync(user.Id, ordetitem);
            return RedirectToAction("Products");
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

        public async Task<IActionResult> Question()
        {
            var userJson = Request.Cookies["account"];
            var user = JsonConvert.DeserializeObject<UserViewDto>(userJson);
            var mesages = await this.messageService.GetAllForUserAsync(user.Id);
            var results = mesages.Where(m=> m.UserId== user.Id).ToList();
            return View(results);
        }

        public async Task<IActionResult> MessageCreate()
        {
            return View();
        }
        public async Task<IActionResult> SendMessage(MessageCreationDto message)
        {
			var userJson = Request.Cookies["account"];
			var user = JsonConvert.DeserializeObject<UserViewDto>(userJson);
			var newMessage = new MessageCreationDto()
            {
                Text = message.Text,
                Type = MessageType.Question,
                UserId = user.Id,
            };
            var result = await this.messageService.CreateAsync(newMessage);
            return RedirectToAction("Question");
        }

	}
}
