using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class AddAccountRequest
    {
        [StringLength(3, MinimumLength = 1)]
        [Required]
        public string Currency { get; set; }
    }
}
