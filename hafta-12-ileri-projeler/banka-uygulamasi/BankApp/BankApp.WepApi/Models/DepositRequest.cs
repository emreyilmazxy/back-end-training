using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class DepositRequest
    {
        [Required(ErrorMessage = "Tutar zorunludur.")]
        [Range(1, double.MaxValue, ErrorMessage = "Tutar 0'dan büyük olmalıdır.")]
        public decimal Amount { get; set; }

        [MaxLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string? Description { get; set; }
        
    }
}
