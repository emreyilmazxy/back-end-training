using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Order.Dtos
{
    // DTO representing detailed information about an order
    public class OrderDetailDto
    {
        public int Id { get; set; } // Order ID
        public DateTime OrderDate { get; set; } // Date when the order was placed
        public decimal TotalAmount { get; set; } // Total amount for the order
        public string Status { get; set; } // Current status of the order
        public List<OrderDetailItemDto> Items { get; set; } // List of items in the order
    }

    // DTO representing detailed information about a single item in an order
    public class OrderDetailItemDto
    {
        public int ProductId { get; set; } // ID of the product
        public string ProductName { get; set; } // Name of the product
        public int Quantity { get; set; } // Quantity of the product
        public decimal Price { get; set; } // Price of the product
    }
}
