using Microsoft.AspNetCore.Mvc;
using mvcproje.Models;

namespace mvcproje.Controllers
{
    public class CustomerOrdersController : Controller
    {
        public IActionResult Index()
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Emre",
                LastName = "Yılmaz",
                Email = "emre@example.com"
            };

            var order1 = new Order
            {
                Id = 1,
                ProductName = "Kulaklık",
                Price = 450 ,
                Quantity = 1
            };

            var order2 = new Order 
            {
                Id = 2,
                ProductName = "Webcam",
                Price = 850  ,
                Quantity = 1
            };

            var viewModel = new CustomerOrderViewModel
            {
                Customer = customer,
                Orders = new List<Order> { order1, order2 }
            };

            return View(viewModel);
        }
    }
}
