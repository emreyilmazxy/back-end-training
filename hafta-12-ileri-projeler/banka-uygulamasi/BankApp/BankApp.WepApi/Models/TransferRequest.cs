using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Models
{
    public class TransferRequest
    {
        [Required(ErrorMessage = "Alıcı hesap numarası zorunludur.")]
        [StringLength(30, ErrorMessage = "Alıcı hesap numarası çok uzun.")]
        public string ReceiverAccountNumber { get; set; } //--

        [Required(ErrorMessage = "Tutar zorunludur.")]
        [Range(1, double.MaxValue, ErrorMessage = "Tutar 0'dan büyük olmalıdır.")]
        public decimal Amount { get; set; } //--

        [MaxLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string? Description { get; set; } //--
        [Required(ErrorMessage = "hesap seçmek zorunludur.")]
        [Range(0, double.MaxValue)]
        public int SenderAccountId { get; set; }//--
    }
    }

