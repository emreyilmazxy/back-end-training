using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Business.Operations.Category.Dtos;
using OnlineShoppingApp.Business.Types;
using OnlineShoppingApp.Data.Entities;
using OnlineShoppingApp.Data.Repositories;
using OnlineShoppingApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<ProductEntity> _productRepository;
        private readonly IRepository<CategoryEntity> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IRepository<CategoryEntity> categoryRepository, IUnitOfWork unitOfWork, IRepository<ProductEntity> productRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<ServiceMessage<AddCategoryDto>> AddCategoryAsync(AddCategoryDto request)
        {
            var entity = new CategoryEntity
            {
                CategoryName = request.CategoryName,
            };

            await _categoryRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            var newCategory = new AddCategoryDto
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
            };

            return new ServiceMessage<AddCategoryDto>
            {
                IsSuccess = true,
                Message = "Category successfully added",
                Data = newCategory
            };
        }

        public async Task<ServiceMessage> DeleteCategoryAsync(int id)
        {
            // Check if the category exists
            var entity = await _categoryRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Category not found"
                };
            }

            // Check if there are any products linked to this category
            var hasProducts = await _productRepository
                .GetAll(p => p.CategoryId == id && !p.IsDeleted)
                .AnyAsync();

            if (hasProducts)
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "Category cannot be deleted because it has linked products"
                };
            }

            // Delete the category
            await _categoryRepository.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage
            {
                IsSuccess = true,
                Message = "Category successfully deleted"
            };
        }

        public async Task<List<CategoryWithProductsDto>> GetAllCategoriesAsync()
        {
            // Retrieve all categories with their products
            return await _categoryRepository.GetAll()
                .Select(c => new CategoryWithProductsDto
                {
                    CategoryId = c.Id,
                    CategoryName = c.CategoryName,
                    Products = c.Products.Select(p => new ProductVm
                    {
                        ProductId = p.Id,
                        ProductName = p.ProductName,
                        Price = p.Price
                    }).ToList()
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ServiceMessage<CategoryWithProductsDto>> GetCategory(int id)
        {
            // Retrieve a single category with its products
            var entity = await _categoryRepository.GetAll(c => c.Id == id)
                .Select(c => new CategoryWithProductsDto
                {
                    CategoryId = c.Id,
                    CategoryName = c.CategoryName,
                    Products = c.Products.Select(p => new ProductVm
                    {
                        ProductId = p.Id,
                        ProductName = p.ProductName,
                        Price = p.Price
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (entity == null)
            {
                return new ServiceMessage<CategoryWithProductsDto>
                {
                    IsSuccess = false,
                    Message = "Category not found"
                };
            }

            return new ServiceMessage<CategoryWithProductsDto>
            {
                IsSuccess = true,
                Data = entity
            };
        }

        public async Task<ServiceMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            // Check if the category exists before updating
            var entity = await _categoryRepository.GetByIdAsync(updateCategoryDto.Id);
            if (entity == null)
            {
                return new ServiceMessage
                {
                    IsSuccess = false,
                    Message = "kategori bulunamadı"
                };
            }

            // Update category name
            entity.CategoryName = updateCategoryDto.CategoryName;

            await _categoryRepository.UpdateAsync(entity); 
            await _unitOfWork.SaveChangesAsync();

            return new ServiceMessage
            {
                IsSuccess = true,
                Message = "kategori başarıyla güncellendi"
            };
        }
    }
}
