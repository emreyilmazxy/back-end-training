using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class VerifyOtpRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string OtpCode { get; set; }
    }
}
