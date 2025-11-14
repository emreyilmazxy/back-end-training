using OnlineShoppingApp.Business.Operations.Order.Dtos;
using OnlineShoppingApp.Business.Operations.Order.Dtos.OnlineShoppingApp.Business.Operations.Order.Dtos;
using OnlineShoppingApp.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Order
{
    // Order management operations contract
    public interface IOrderService
    {
        Task<ServiceMessage<AddOrderDto>> AddOrderAsync(AddOrderDto dto);
        Task<ServiceMessage<OrderDetailDto>> GetOrderByIdAsync(int id);
        Task<ServiceMessage<List<OrderSummaryDto>>> GetAllOrdersAsync();
        Task<ServiceMessage> DeleteOrderAsync(int id);
    } // IOrderService interface done
}
