using OnlineShoppingApp.Business.Operations.Category.Dtos;
using OnlineShoppingApp.Business.Types;
using OnlineShoppingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Category
{
    // Category-related business operations contract
    public interface ICategoryService
    {
        Task<ServiceMessage<AddCategoryDto>> AddCategoryAsync(AddCategoryDto request);
        Task<ServiceMessage<CategoryWithProductsDto>> GetCategory(int id);
        Task<List<CategoryWithProductsDto>> GetAllCategoriesAsync();
        Task<ServiceMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<ServiceMessage> DeleteCategoryAsync(int id);
    }// CategoryService interface done
}
