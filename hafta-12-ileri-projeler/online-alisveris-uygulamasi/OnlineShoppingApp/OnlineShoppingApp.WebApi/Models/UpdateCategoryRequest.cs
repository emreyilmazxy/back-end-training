using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.WebApi.Models
{
    public class UpdateCategoryRequest
    {
        [Required]
        [MinLength(1, ErrorMessage = "Kategori adı boş olamaz.")]
        [MaxLength(50, ErrorMessage = "Kategori adı 50 karakteri geçemez.")]
        public string CategoryName { get; set; }
    }// UpdateCategoryRequest class done
}
