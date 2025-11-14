using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola zorunludur.")]
        [MaxLength(50, ErrorMessage ="parola 50 karakterden uzun olamaz")]
        public string Password { get; set; }
    }
}
