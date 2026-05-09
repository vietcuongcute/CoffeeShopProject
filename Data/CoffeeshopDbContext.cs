using CoffeeShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Data
{
    public class CoffeeshopDbContext : IdentityDbContext
    {
        public CoffeeshopDbContext(DbContextOptions<CoffeeshopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
    new Product
    {
        Id = 1,
        Name = "America",
        Price = 25000,
        Detail = "Cà phê America thơm nhẹ, vị thanh và dễ uống.",
        ImageUrl = "https://images.unsplash.com/photo-1509042239860-f550ce710b93?auto=format&fit=crop&w=900&q=80",
        IsTrendingProduct = true
    },
    new Product
    {
        Id = 2,
        Name = "Vietnam",
        Price = 20000,
        Detail = "Cà phê Việt Nam đậm vị, hương thơm mạnh mẽ.",
        ImageUrl = "https://images.unsplash.com/photo-1495474472287-4d71bcdd2085?auto=format&fit=crop&w=900&q=80",
        IsTrendingProduct = true
    },
    new Product
    {
        Id = 3,
        Name = "United Kingdom",
        Price = 30000,
        Detail = "Cà phê phong cách Anh, dịu nhẹ và cân bằng.",
        ImageUrl = "https://images.unsplash.com/photo-1442512595331-e89e73853f31?auto=format&fit=crop&w=900&q=80",
        IsTrendingProduct = false
    },
    new Product
    {
        Id = 4,
        Name = "India",
        Price = 28000,
        Detail = "Cà phê India đậm đà, hậu vị ấm.",
        ImageUrl = "https://images.unsplash.com/photo-1514432324607-a09d9b4aefdd?auto=format&fit=crop&w=900&q=80",
        IsTrendingProduct = false
    },
    new Product
    {
        Id = 5,
        Name = "France",
        Price = 35000,
        Detail = "Cà phê Pháp sang trọng, hương vị tinh tế.",
        ImageUrl = "https://images.unsplash.com/photo-1511920170033-f8396924c348?auto=format&fit=crop&w=900&q=80",
        IsTrendingProduct = true
    }
);
        }
    }
}