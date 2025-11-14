using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Business.Operations.Product.Dtos;
using OnlineShoppingApp.Business.Types;
using OnlineShoppingApp.Data.Entities;
using OnlineShoppingApp.Data.Repositories;
using OnlineShoppingApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Product
{
    public class ProductServise : IProductService
    {
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CategoryEntity> _categoryRepository;

        public ProductServise(IRepository<ProductEntity> productRepository, IUnitOfWork unitOfWork, IRepository<CategoryEntity> categoryRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
           _categoryRepository = categoryRepository;
            
        }
        public async Task<ServiceMessage<AddProductDto>> AddProductAsync(AddProductDto addProductDto)
        {
            var hasCategory = await _categoryRepository.GetByIdAsync(addProductDto.CategoryId);
            if (hasCategory == null)
            {
                return new ServiceMessage<AddProductDto>
                {
                    IsSuccess = false,
                    Message = "Kategori bulunamadı"
                };
            }

            var productEntity = new ProductEntity
            {
                CategoryId = addProductDto.CategoryId,
                ProductName = addProductDto.ProductName,
                Price = addProductDto.Price,
                StockQuantity = addProductDto.StockQuantity
            };
            await _productRepository.AddAsync(productEntity);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceMessage<AddProductDto>
            {
                IsSuccess = true,
                Message = "Ürün başarıyla eklendi",
                Data = new AddProductDto
                {
                    Id = productEntity.Id,
                    CategoryId = productEntity.CategoryId,
                    ProductName = productEntity.ProductName,
                    Price = productEntity.Price,
                    StockQuantity = productEntity.StockQuantity
                }
            };
        }

        public async Task<ServiceMessage> ApplyPartialUpdateAsync(PatchProductDto dto)
        {
            var entity = await _productRepository.GetByIdAsync(dto.Id);
            if (entity == null)
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Ürün bulunamadı"
                };
            }

            entity.Price = dto.Price;
             entity.StockQuantity = dto.StockQuantity;


            await _productRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceMessage
            {
                IsSuccess = true,
            };

        }

        public async Task<ServiceMessage> DeleteProductAsync(int id)
        {
           var product = await _productRepository.GetAsync(p => p.Id == id);
            if (product == null)
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Ürün bulunamadı"
                };
            }
            await _productRepository.DeleteAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceMessage
            {
                IsSuccess = true,
                Message = "Ürün başarıyla silindi"
            };
        }

        public async Task<List<ProductListDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAll().AsNoTracking().ToListAsync();

            var dtoList = products.Select(p => new ProductListDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CategoryId = p.CategoryId
            }).ToList();

            return dtoList;
        }

        public async Task<ServiceMessage<ProductListDto>> GetProductByIdAsync(int id)
        {
            var product =  await _productRepository.GetAll()
                .Where(p => p.Id == id)
                .Select(p => new ProductListDto
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId
                }).FirstOrDefaultAsync();   
            if (product == null)
                {
                return new ServiceMessage<ProductListDto>
                {
                    IsSuccess = false,
                    Message = "Ürün bulunamadı"
                };
            }
            return new ServiceMessage<ProductListDto>
            {
                IsSuccess = true,
                Data = product
            };
        }

        public async Task<ServiceMessage> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
              var product = await _productRepository.GetByIdAsync(updateProductDto.Id);
            if (product == null)
                {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Ürün bulunamadı"
                };
            }
            product.CategoryId = updateProductDto.CategoryId;
            product.ProductName = updateProductDto.ProductName;
            product.Price = updateProductDto.Price;
            product.StockQuantity = updateProductDto.StockQuantity;

            await _productRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return new ServiceMessage
            {
                IsSuccess = true,
                Message = "Ürün başarıyla güncellendi"
            };
        }
    } // ProductServise done
}
