using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.WebApi.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola zorunludur.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Parola 6 ile 50 karakter arasında olmalıdır.")]
        public string Password { get; set; }
    } // loginrequest done
}
