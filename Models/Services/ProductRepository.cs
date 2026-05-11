using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly CoffeeshopDbContext dbContext;

        public ProductRepository(CoffeeshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .ToList();
        }

        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Products
                .AsNoTracking()
                .Where(p => p.IsTrendingProduct)
                .OrderBy(p => p.Name)
                .Take(3)
                .ToList();
        }

        public Product? GetProductDetail(int id)
        {
            return dbContext.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }
    }
}