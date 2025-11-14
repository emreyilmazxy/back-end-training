using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.WebApi.Models
{
    public class PatchProductRequest
    {

        [Required]
       
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Stok en az 1 olmalı.")]
        public int StockQuantity { get; set; }
    } // PatchProductRequest done
}
