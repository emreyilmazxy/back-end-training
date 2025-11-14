using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShoppingApp.Business.Operations.Category;
using OnlineShoppingApp.Business.Operations.Category.Dtos;
using OnlineShoppingApp.WebApi.Models;

namespace OnlineShoppingApp.WebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> CategoryAdd(CategoryAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addCategoryDto = new AddCategoryDto
            {
                CategoryName = request.CategoryName,
            };
            var result = await _categoryService.AddCategoryAsync(addCategoryDto);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);

        }

        [HttpGet]
        [Route("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            

            if (id <= 0)
            {
                return BadRequest("Geçersiz kategori ID");
            }
            var category = await _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            return Ok(category);
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            IMemoryCache cache = HttpContext.RequestServices.GetRequiredService<IMemoryCache>();
            if (cache.TryGetValue("all_categories", out List<CategoryDto> cachedCategories))
            {
                return Ok(cachedCategories);
            }
            var categories = await _categoryService.GetAllCategoriesAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound("Kategoriler bulunamadı");
            }

            cache.Set("all_cateegories", categories, TimeSpan.FromMinutes(5));
            return Ok(categories);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UptadeCategory(int id ,UpdateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updateCategoryDto = new UpdateCategoryDto
            {
                Id = id,
                CategoryName = request.CategoryName,
            };
            var result = await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz kategori ID");
            }
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }
            return NoContent();
        }

    } // CategoriesController class done
}
