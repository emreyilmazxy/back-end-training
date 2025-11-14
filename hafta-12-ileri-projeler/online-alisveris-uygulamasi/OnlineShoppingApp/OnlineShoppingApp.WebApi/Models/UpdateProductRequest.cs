using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.WebApi.Models
{
    public class UpdateProductRequest
    {
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kategori seçin.")]
        public int CategoryId { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string ProductName { get; set; }
        [Required]
        
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "stok negatif bir değer olamaz")]
        public int StockQuantity { get; set; }
    } // UpdateProductRequest done
}
