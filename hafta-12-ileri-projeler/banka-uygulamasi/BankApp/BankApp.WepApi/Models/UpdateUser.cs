using BankApp.Data.Enums;
using BankApp.WepApi.Validation;
using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class UpdateUser
    {
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "İsim 50 karakterden uzun olamaz.")]
        public string FirstName { get; set; } //--

        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Soyisim 50 karakterden uzun olamaz.")]
        public string LastName { get; set; } //--

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        [DataType(DataType.Date, ErrorMessage = "Geçerli bir tarih giriniz.")]
        public DateTime BirthDate { get; set; } //--

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; } //---

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; } //--

    }
}
