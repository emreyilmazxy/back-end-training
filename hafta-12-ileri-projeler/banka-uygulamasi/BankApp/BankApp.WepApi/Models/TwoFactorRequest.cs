using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class TwoFactorRequest
    {
        [Required]
        public bool IsTwoFactorEnabled { get; set; }
    }
}
