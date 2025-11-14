using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Business.Operations.Order;
using OnlineShoppingApp.Business.Operations.Order.Dtos.OnlineShoppingApp.Business.Operations.Order.Dtos;
using OnlineShoppingApp.WebApi.Filters;
using OnlineShoppingApp.WebApi.Models;
using System.Security.Claims;

namespace OnlineShoppingApp.WebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        [Route("add")]
        [TimeControlFilter]
        public async Task<IActionResult> AddOrder(AddOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier)
                                 ?? User.FindFirstValue("sub")
                                 ?? User.FindFirstValue("id");
            
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out var userId))
                return Unauthorized(new { message = "kullanıcı kimliği alınamadı" });
          
            var dto = new AddOrderDto()
            {
                OrderId = 0, 
                UserId = userId,
                    Items = request.Items.Select(item => new AddOrderItemDto
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    }).ToList()
            };
            var result = await _orderService.AddOrderAsync(dto);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data.OrderId }, result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz sipariş ID");
            }
            var result = await _orderService.GetOrderByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderService.GetAllOrdersAsync(); 
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(result.Data); 
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);

            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return NoContent(); // 204
        }

    } // End of OrdersController
}
