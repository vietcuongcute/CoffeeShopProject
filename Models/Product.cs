using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên món là bắt buộc.")]
        public string Name { get; set; } = string.Empty;

        public string Detail { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Range(1000, 10000000, ErrorMessage = "Giá phải lớn hơn hoặc bằng 1.000 đ.")]
        public decimal Price { get; set; }

        public bool IsTrendingProduct { get; set; }
    }
}