using CoffeeShop.Data;
using CoffeeShop.Extensions;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class OrdersController : Controller
    {
        private const string CartSessionKey = "Cart";
        private readonly CoffeeshopDbContext _dbContext;

        public OrdersController(CoffeeshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Checkout()
        {
            var cart = GetCart();

            if (!cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var cart = GetCart();

            if (!cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            if (!ModelState.IsValid)
            {
                return View(order);
            }

            order.TotalAmount = cart.Sum(item => item.Total);
            order.OrderDate = DateTime.Now;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            HttpContext.Session.Remove(CartSessionKey);

            return RedirectToAction("Success");
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