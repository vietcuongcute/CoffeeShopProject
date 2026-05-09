using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Detail { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsTrendingProduct { get; set; }
    }
}