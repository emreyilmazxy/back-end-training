using BankApp.WepApi.Validation;
using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
   
        public class ChangePasswordRequest
        {
            [Required(ErrorMessage = "Mevcut şifre gereklidir.")]
            public string CurrentPassword { get; set; }

            [Required(ErrorMessage = "Yeni şifre gereklidir.")]
            [StrongPassword]
            public string NewPassword { get; set; }
        }
}
