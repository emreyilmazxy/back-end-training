using BankApp.Data.Entities;
using BankApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class PayBillRequest
    {
        [Required]
        public int AccountId { get; set; } // Kullanıcının ödeme yapacağı hesap ID

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Tutar 1’den büyük olmalıdır.")]
        public decimal Amount { get; set; }

       






    }// end of class BillEntity
}

