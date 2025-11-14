using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Business.Operations.Order.Dtos;
using OnlineShoppingApp.Business.Operations.Order.Dtos.OnlineShoppingApp.Business.Operations.Order.Dtos;
using OnlineShoppingApp.Business.Types;
using OnlineShoppingApp.Data.Entities;
using OnlineShoppingApp.Data.Enums;
using OnlineShoppingApp.Data.Repositories;
using OnlineShoppingApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Order
{
    // Order-related business operations
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<OrderEntity> _orderRepository;
        private readonly IRepository<ProductEntity> _productRepository;

        public OrderService(IUnitOfWork unitOfWork, IRepository<OrderEntity> orderRepository, IRepository<ProductEntity> productRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<ServiceMessage<AddOrderDto>> AddOrderAsync(AddOrderDto dto)
        {
            await _unitOfWork.BeginTransactionAsync();

            var productIds = dto.Items.Select(i => i.ProductId).Distinct().ToList();
            var products = await _productRepository
                .GetAll(p => productIds.Contains(p.Id) && !p.IsDeleted)
                .ToListAsync();

            if (products.Count != productIds.Count)
                return new ServiceMessage<AddOrderDto> { IsSuccess = false, Message = "Geçersiz ürünler var." };

            decimal total = 0;
            foreach (var item in dto.Items)
            {
                var prod = products.First(p => p.Id == item.ProductId);

                if (item.Quantity <= 0)
                    return new ServiceMessage<AddOrderDto> { IsSuccess = false, Message = "Adet 1 veya daha büyük olmalı." };
                if (prod.StockQuantity < item.Quantity)
                    return new ServiceMessage<AddOrderDto> { IsSuccess = false, Message = $"Yetersiz stok: {prod.ProductName}" };

                total += prod.Price * item.Quantity;

                prod.StockQuantity -= item.Quantity;
                await _productRepository.UpdateAsync(prod);
            }

            var orderEntity = new OrderEntity
            {
                UserId = dto.UserId,
                OrderDate = DateTime.Now,
                TotalAmount = total,
                Status = OrderStatus.Pending,
                OrderProducts = dto.Items.Select(it => new OrderProductEntity
                {
                    ProductId = it.ProductId,
                    Quantity = it.Quantity
                }).ToList()
            };

            await _orderRepository.AddAsync(orderEntity);

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return new ServiceMessage<AddOrderDto>
            {
                IsSuccess = true,
                Message = "Sipariş başarıyla eklendi",
                Data = new AddOrderDto
                {
                    OrderId = orderEntity.Id,
                    UserId = dto.UserId,
                    Items = dto.Items
                }
            };
        }

        public async Task<ServiceMessage> DeleteOrderAsync(int id)
        {
            var entity = await _orderRepository.GetByIdAsync(id);

            if (entity is null || entity.IsDeleted)
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Sipariş bulunamadı"
                };
            }
            entity.Status = (OrderStatus)4; // Cancelled
            await _orderRepository.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage
            {
                IsSuccess = true,
                Message = "Sipariş başarıyla silindi"
            };
        }

        public async Task<ServiceMessage<List<OrderSummaryDto>>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository
                .GetAll()
                .AsNoTracking()
                .Select(o => new OrderSummaryDto
                {
                    Id = o.Id,
                      ProductNames = o.OrderProducts.Select(p => p.Product.ProductName).ToList(),
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status.ToString()
                })
                .ToListAsync();

            if (orders.Count == 0)
                return new ServiceMessage<List<OrderSummaryDto>>
                {
                    IsSuccess = false,
                    Message = "Sipariş bulunamadı."
                };

            return new ServiceMessage<List<OrderSummaryDto>>
            {
                IsSuccess = true,
                Data = orders
            };
        }

        public async Task<ServiceMessage<OrderDetailDto>> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository
                .GetAll(o => o.Id == id)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync();

            if (order == null)
                return new ServiceMessage<OrderDetailDto>
                {
                    IsSuccess = false,
                    Message = "Sipariş bulunamadı"
                };

            var dto = new OrderDetailDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                Items = order.OrderProducts.Select(op => new OrderDetailItemDto
                {
                    ProductId = op.ProductId,
                    ProductName = op.Product.ProductName,
                    Quantity = op.Quantity,
                    Price = op.Product.Price
                }).ToList()
            };

            return new ServiceMessage<OrderDetailDto>()
            {
                IsSuccess = true,
                Message = "Sipariş detayları başarıyla getirildi",
                Data = dto
            };
        }
    } // OrderService class done
}
