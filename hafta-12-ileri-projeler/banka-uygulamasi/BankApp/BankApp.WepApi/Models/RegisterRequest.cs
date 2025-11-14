using BankApp.Data.Enums;
using BankApp.WepApi.Validation;
using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "İsim 50 karakterden uzun olamaz.")]
        public string FirstName { get; set; } // --

        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Soyisim 50 karakterden uzun olamaz.")]
        public string LastName { get; set; } // --

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; } //--

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; } // ---

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MaxLength(100)]
        [StrongPassword]
        [DataType(DataType.Password)]
        public string Password { get; set; } // ---

        [Required(ErrorMessage = "Şifre tekrar alanı zorunludur.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } // ---
        [Required(ErrorMessage = "doğum tarihi zorunludur")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        
    } // end of class RegisterRequestModel
}
