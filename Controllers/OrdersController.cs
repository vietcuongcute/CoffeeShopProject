using CoffeeShop.Data;
using CoffeeShop.Extensions;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private const string CartSessionKey = "Cart";

        private readonly CoffeeshopDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdersController(
            CoffeeshopDbContext dbContext,
            UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Checkout()
        {
            return RedirectToAction(nameof(PlaceOrder));
        }

        public async Task<IActionResult> PlaceOrder()
        {
            var cart = GetCart();

            if (!cart.Any())
            {
                TempData["ErrorMessage"] = "Giỏ hàng đang trống.";
                return RedirectToAction("Index", "Cart");
            }

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var email = currentUser.Email ?? User.Identity?.Name ?? "customer";
            var customerName = email.Split('@')[0];

            var order = new Order
            {
                CustomerName = customerName,
                CustomerPhone = currentUser.PhoneNumber ?? "Chưa cập nhật",
                CustomerAddress = "Không yêu cầu nhập lại thông tin",
                TotalAmount = cart.Sum(item => item.Total),
                OrderDate = DateTime.Now
            };

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            HttpContext.Session.Remove(CartSessionKey);

            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            return View();
        }

        private List<CartItem> GetCart()
        {
            return HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey)
                   ?? new List<CartItem>();
        }
    }
}