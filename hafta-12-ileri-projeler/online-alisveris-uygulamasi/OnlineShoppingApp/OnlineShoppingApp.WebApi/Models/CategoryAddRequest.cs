using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.WebApi.Models
{
    public class CategoryAddRequest
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }// CategoryAddRequest class done
}
