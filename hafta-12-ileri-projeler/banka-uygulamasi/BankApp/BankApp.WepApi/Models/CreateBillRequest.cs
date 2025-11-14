using BankApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class CreateBillRequest
    {
        [Required]
        public BillType BillType { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Tutar 1’den büyük olmalıdır.")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

      
    }
}
