using OnlineShoppingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Order.Dtos
{
    // DTO representing a summarized view of an order
    public class OrderSummaryDto
    {
        public int Id { get; set; } // Order ID
        public DateTime OrderDate { get; set; } // Date when the order was placed
        public decimal TotalAmount { get; set; } // Total amount for the order
        public string Status { get; set; } // Current status of the order

        public List<string> ProductNames { get; set; } = new List<string>();
    } // OrderSummaryDto class done
}
