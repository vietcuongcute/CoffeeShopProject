using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Shop()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = _productRepository.GetProductDetail(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}