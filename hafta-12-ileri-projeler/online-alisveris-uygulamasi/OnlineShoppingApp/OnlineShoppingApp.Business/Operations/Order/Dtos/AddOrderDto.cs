using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Order.Dtos
{
    namespace OnlineShoppingApp.Business.Operations.Order.Dtos
    {
        // DTO for adding a new order
        public class AddOrderDto
        {
            public int UserId { get; set; } // ID of the user placing the order
            public int OrderId { get; set; } // Unique identifier for the order
            public List<AddOrderItemDto> Items { get; set; } = new(); // List of items in the order
        }

        // DTO for adding an item to an order
        public class AddOrderItemDto
        {
            public int ProductId { get; set; } // ID of the product being ordered
            public int Quantity { get; set; }  // Quantity of the product
        }
    } // AddOrderDto class done
}
