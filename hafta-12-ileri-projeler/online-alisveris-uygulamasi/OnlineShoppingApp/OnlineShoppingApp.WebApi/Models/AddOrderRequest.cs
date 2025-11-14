namespace OnlineShoppingApp.WebApi.Models;
using System.ComponentModel.DataAnnotations;

public class AddOrderRequest
{
   

    [Required]
    [MinLength(1, ErrorMessage = "En az bir ürün seçmelisiniz.")]
    public List<AddOrderItemRequest> Items { get; set; } = new();
}

public class AddOrderItemRequest
{
    [Required]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Adet 1 veya daha büyük olmalı.")]
    public int Quantity { get; set; }
}
